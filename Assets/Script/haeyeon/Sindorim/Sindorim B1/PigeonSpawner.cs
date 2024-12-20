using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    public Transform player;  // 플레이어의 Transform
    public GameObject pigeonPrefab;  // 비둘기 Prefab
    public Transform pillar;  // 기준 기둥
    public SpriteRenderer mapSprite;  // 맵의 SpriteRenderer
    public float pigeonSpeed = 5f;  // 비둘기 이동 속도
    public float spawnInterval = 10f;  // 비둘기 생성 간격 (초)

    private float nextSpawnTime = 0f;  // 다음 생성 시간
    private int currentDirection = 0;  // 현재 비둘기 생성 방향 (0: 상, 1: 하, 2: 좌, 3: 우)
    private bool canSpawn = false;  // 생성 가능 상태

    void Update()
    {
        // 플레이어가 기둥 아래로 내려갔을 때 비둘기 생성 시작
        if (player.position.y < pillar.position.y)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        if (canSpawn && Time.time >= nextSpawnTime)
        {
            SpawnPigeon();
            nextSpawnTime = Time.time + spawnInterval;  // 다음 생성 시간 갱신
        }
    }

    void SpawnPigeon()
    {
        Vector3 spawnPosition = Vector3.zero;
        Vector3 targetPosition = Vector3.zero;

        // 맵 경계 계산
        float mapTopY = mapSprite.bounds.max.y;
        float mapBottomY = mapSprite.bounds.min.y;
        float mapLeftX = mapSprite.bounds.min.x;
        float mapRightX = mapSprite.bounds.max.x;

        // 현재 방향에 따라 생성 위치와 목표 위치 설정
        switch (currentDirection)
        {
            case 0: // 상 (위에서 아래로)
                spawnPosition = new Vector3(player.position.x, mapTopY, 0);
                targetPosition = new Vector3(player.position.x, mapBottomY, 0);
                break;
            case 1: // 하 (아래에서 위로)
                spawnPosition = new Vector3(player.position.x, mapBottomY, 0);
                targetPosition = new Vector3(player.position.x, mapTopY, 0);
                break;
            case 2: // 좌 (왼쪽에서 오른쪽으로)
                spawnPosition = new Vector3(mapLeftX, player.position.y, 0);
                targetPosition = new Vector3(mapRightX, player.position.y, 0);
                break;
            case 3: // 우 (오른쪽에서 왼쪽으로)
                spawnPosition = new Vector3(mapRightX, player.position.y, 0);
                targetPosition = new Vector3(mapLeftX, player.position.y, 0);
                break;
        }

        // 비둘기 생성
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);

        // 비둘기의 PigeonMovement 스크립트에 속도와 목표 위치 설정
        PigeonMoving movement = pigeon.GetComponent<PigeonMoving>();
        if (movement != null)
        {
            movement.Initialize(targetPosition, pigeonSpeed);
        }

        // 다음 방향으로 변경
        currentDirection = (currentDirection + 1) % 4;
    }
}