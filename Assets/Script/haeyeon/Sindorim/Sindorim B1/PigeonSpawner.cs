using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    public Transform player;  // �÷��̾��� Transform
    public GameObject pigeonPrefab;  // ��ѱ� Prefab
    public Transform pillar;  // ���� ���
    public SpriteRenderer mapSprite;  // ���� SpriteRenderer
    public float pigeonSpeed = 5f;  // ��ѱ� �̵� �ӵ�
    public float spawnInterval = 10f;  // ��ѱ� ���� ���� (��)

    private float nextSpawnTime = 0f;  // ���� ���� �ð�
    private int currentDirection = 0;  // ���� ��ѱ� ���� ���� (0: ��, 1: ��, 2: ��, 3: ��)
    private bool canSpawn = false;  // ���� ���� ����

    void Update()
    {
        // �÷��̾ ��� �Ʒ��� �������� �� ��ѱ� ���� ����
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
            nextSpawnTime = Time.time + spawnInterval;  // ���� ���� �ð� ����
        }
    }

    void SpawnPigeon()
    {
        Vector3 spawnPosition = Vector3.zero;
        Vector3 targetPosition = Vector3.zero;

        // �� ��� ���
        float mapTopY = mapSprite.bounds.max.y;
        float mapBottomY = mapSprite.bounds.min.y;
        float mapLeftX = mapSprite.bounds.min.x;
        float mapRightX = mapSprite.bounds.max.x;

        // ���� ���⿡ ���� ���� ��ġ�� ��ǥ ��ġ ����
        switch (currentDirection)
        {
            case 0: // �� (������ �Ʒ���)
                spawnPosition = new Vector3(player.position.x, mapTopY, 0);
                targetPosition = new Vector3(player.position.x, mapBottomY, 0);
                break;
            case 1: // �� (�Ʒ����� ����)
                spawnPosition = new Vector3(player.position.x, mapBottomY, 0);
                targetPosition = new Vector3(player.position.x, mapTopY, 0);
                break;
            case 2: // �� (���ʿ��� ����������)
                spawnPosition = new Vector3(mapLeftX, player.position.y, 0);
                targetPosition = new Vector3(mapRightX, player.position.y, 0);
                break;
            case 3: // �� (�����ʿ��� ��������)
                spawnPosition = new Vector3(mapRightX, player.position.y, 0);
                targetPosition = new Vector3(mapLeftX, player.position.y, 0);
                break;
        }

        // ��ѱ� ����
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);

        // ��ѱ��� PigeonMovement ��ũ��Ʈ�� �ӵ��� ��ǥ ��ġ ����
        PigeonMoving movement = pigeon.GetComponent<PigeonMoving>();
        if (movement != null)
        {
            movement.Initialize(targetPosition, pigeonSpeed);
        }

        // ���� �������� ����
        currentDirection = (currentDirection + 1) % 4;
    }
}