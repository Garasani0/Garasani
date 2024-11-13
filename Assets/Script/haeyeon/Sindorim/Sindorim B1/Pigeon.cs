using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Transform player;    // Player의 Transform
    public GameObject pigeonPrefab; // 비둘기 프리팹
    public Transform pillar;    // 기둥 오브젝트의 Transform
    public Transform groundObject;  // '[바닥]지하 2층' 오브젝트의 Transform
    public float pigeonSpeed = 2f;  // 비둘기의 상승 속도

    private float pigeonSpawnY;  // 비둘기가 생성될 y 좌표 (지하 2층의 밑 모서리)
    private float mapEndY;       // 비둘기가 사라질 y 좌표 (지하 2층의 위 모서리)
    private bool pigeonSpawned = false; // 비둘기 생성 여부

    void Start()
    {
        // '[바닥]지하 2층'의 Position과 Scale을 사용하여 밑 모서리와 위 모서리 계산
        Vector3 groundPosition = groundObject.position;
        Vector3 groundScale = groundObject.localScale;

        // 밑 모서리와 위 모서리를 계산 (Scale의 y값을 기준으로 경계 설정)
        pigeonSpawnY = groundPosition.y - (groundScale.y * 0.5f * 10);  // 밑 모서리
        mapEndY = groundPosition.y + (groundScale.y * 0.5f * 10);       // 위 모서리
    }

    void Update()
    {
        // Player가 기둥의 y 좌표보다 아래로 내려갔을 때 비둘기를 생성
        if (!pigeonSpawned && player.position.y < pillar.position.y)
        {
            SpawnPigeon();
        }
    }

    void SpawnPigeon()
    {
        // Player의 x 좌표에 맞춰서 비둘기 생성, y 좌표는 '[바닥]지하 2층'의 밑 모서리
        Vector3 spawnPosition = new Vector3(player.position.x, pigeonSpawnY, 0);
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);
        pigeonSpawned = true;

        // 비둘기 스크립트에서 위로 이동하도록 처리
        PigeonMovement pigeonMovement = pigeon.GetComponent<PigeonMovement>();
        pigeonMovement.SetMapEndY(mapEndY);
    }
}