using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Transform player;
    public GameObject pigeonPrefab;
    public Transform pillar;
    public Transform groundObject;
    public float pigeonSpeed = 2f;

    private float pigeonSpawnY;
    private float mapEndY;
    private bool pigeonSpawned = false;

    void Start()
    {
        Vector3 groundPosition = groundObject.position;
        Vector3 groundScale = groundObject.localScale;

        pigeonSpawnY = groundPosition.y - (groundScale.y * 0.5f * 10);
        mapEndY = groundPosition.y + (groundScale.y * 0.5f * 10);
    }

    void Update()
    {
        if (!pigeonSpawned && player.position.y < pillar.position.y)
        {
            SpawnPigeon();
        }
    }

    void SpawnPigeon()
    {
        Vector3 spawnPosition = new Vector3(player.position.x, pigeonSpawnY, 0);
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);
        pigeonSpawned = true;

        PigeonMovement pigeonMovement = pigeon.GetComponent<PigeonMovement>();
        pigeonMovement.SetMapEndY(mapEndY);
    }
}