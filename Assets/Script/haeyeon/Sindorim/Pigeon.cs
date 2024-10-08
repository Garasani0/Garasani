using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Transform player;    // Player�� Transform
    public GameObject pigeonPrefab; // ��ѱ� ������
    public Transform pillar;    // ��� ������Ʈ�� Transform
    public Transform groundObject;  // '[�ٴ�]���� 2��' ������Ʈ�� Transform
    public float pigeonSpeed = 2f;  // ��ѱ��� ��� �ӵ�

    private float pigeonSpawnY;  // ��ѱⰡ ������ y ��ǥ (���� 2���� �� �𼭸�)
    private float mapEndY;       // ��ѱⰡ ����� y ��ǥ (���� 2���� �� �𼭸�)
    private bool pigeonSpawned = false; // ��ѱ� ���� ����

    void Start()
    {
        // '[�ٴ�]���� 2��'�� Position�� Scale�� ����Ͽ� �� �𼭸��� �� �𼭸� ���
        Vector3 groundPosition = groundObject.position;
        Vector3 groundScale = groundObject.localScale;

        // �� �𼭸��� �� �𼭸��� ��� (Scale�� y���� �������� ��� ����)
        pigeonSpawnY = groundPosition.y - (groundScale.y * 0.5f * 10);  // �� �𼭸�
        mapEndY = groundPosition.y + (groundScale.y * 0.5f * 10);       // �� �𼭸�
    }

    void Update()
    {
        // Player�� ����� y ��ǥ���� �Ʒ��� �������� �� ��ѱ⸦ ����
        if (!pigeonSpawned && player.position.y < pillar.position.y)
        {
            SpawnPigeon();
        }
    }

    void SpawnPigeon()
    {
        // Player�� x ��ǥ�� ���缭 ��ѱ� ����, y ��ǥ�� '[�ٴ�]���� 2��'�� �� �𼭸�
        Vector3 spawnPosition = new Vector3(player.position.x, pigeonSpawnY, 0);
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);
        pigeonSpawned = true;

        // ��ѱ� ��ũ��Ʈ���� ���� �̵��ϵ��� ó��
        PigeonMovement pigeonMovement = pigeon.GetComponent<PigeonMovement>();
        pigeonMovement.SetMapEndY(mapEndY);
    }
}