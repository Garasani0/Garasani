using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    public GameObject pigeonPrefab;  // 비둘기 프리팹
    public Transform player;         // 플레이어 Transform
    public Transform map;            // 맵 Transform (맵의 중심 기준)
    public Transform pillar;         // 기둥 Transform

    public float spawnInterval = 10f; // 비둘기 생성 간격 (초)

    private float mapWidth;           // 맵의 너비 (x축)
    private float mapHeight;          // 맵의 높이 (y축)
    private bool spawning = false;    // 비둘기 생성 활성화 여부

    public float speed = 5f;

    void Start()
    {
        // 맵의 크기를 계산
        SpriteRenderer mapRenderer = map.GetComponent<SpriteRenderer>();
        if (mapRenderer != null)
        {
            mapWidth = mapRenderer.bounds.size.x;
            mapHeight = mapRenderer.bounds.size.y;
        }
        else
        {
            Debug.LogError("Map에 SpriteRenderer가 없습니다. SpriteRenderer를 추가하세요.");
        }
    }

    void Update()
    {
        // 플레이어가 기둥 아래로 내려가면 비둘기 생성 시작
        if (player.position.y < pillar.position.y && !spawning)
        {
            spawning = true;
            StartCoroutine(SpawnPigeons());
        }
    }

    IEnumerator SpawnPigeons()
    {
        while (true)
        {
            SpawnPigeon(Vector2.up);    // 아래 -> 위
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.down);  // 위 -> 아래
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.left);  // 오른쪽 -> 왼쪽
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.right); // 왼쪽 -> 오른쪽
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnPigeon(Vector2 direction)
    {
        Vector3 spawnPosition = Vector3.zero; // 비둘기 시작 위치
        Vector3 targetPosition = Vector3.zero; // 비둘기가 날아가는 목표 위치

        // 방향별로 스폰 위치와 목표 위치 계산
        if (direction == Vector2.up)
        {
            spawnPosition = new Vector3(player.position.x, map.position.y - mapHeight / 2, 0);
            targetPosition = new Vector3(player.position.x, map.position.y + mapHeight / 2, 0);
        }
        else if (direction == Vector2.down)
        {
            spawnPosition = new Vector3(player.position.x, map.position.y + mapHeight / 2, 0);
            targetPosition = new Vector3(player.position.x, map.position.y - mapHeight / 2, 0);
        }
        else if (direction == Vector2.left)
        {
            spawnPosition = new Vector3(map.position.x + mapWidth / 2, player.position.y, 0);
            targetPosition = new Vector3(map.position.x - mapWidth / 2, player.position.y, 0);
        }
        else if (direction == Vector2.right)
        {
            spawnPosition = new Vector3(map.position.x - mapWidth / 2, player.position.y, 0);
            targetPosition = new Vector3(map.position.x + mapWidth / 2, player.position.y, 0);
        }

        // 비둘기 생성
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);

        // 비둘기가 목표 위치로 이동하도록 설정
        Rigidbody2D rb = pigeon.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("비둘기 프리팹에 Rigidbody2D가 없습니다!");
            return;
        }

        rb.gravityScale = 0; // 중력 제거
        float speed = 5f; // 비둘기 속도
        Vector3 directionToTarget = (targetPosition - spawnPosition).normalized; // 방향 벡터 정규화
        rb.velocity = directionToTarget * speed; // 일정한 속도로 설정

        // 비둘기 삭제 처리
        pigeon.AddComponent<PigeonCleaner>().SetTarget(targetPosition);
    }
}