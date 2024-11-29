using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    public GameObject pigeonPrefab;  // ��ѱ� ������
    public Transform player;         // �÷��̾� Transform
    public Transform map;            // �� Transform (���� �߽� ����)
    public Transform pillar;         // ��� Transform

    public float spawnInterval = 10f; // ��ѱ� ���� ���� (��)

    private float mapWidth;           // ���� �ʺ� (x��)
    private float mapHeight;          // ���� ���� (y��)
    private bool spawning = false;    // ��ѱ� ���� Ȱ��ȭ ����

    public float speed = 5f;

    void Start()
    {
        // ���� ũ�⸦ ���
        SpriteRenderer mapRenderer = map.GetComponent<SpriteRenderer>();
        if (mapRenderer != null)
        {
            mapWidth = mapRenderer.bounds.size.x;
            mapHeight = mapRenderer.bounds.size.y;
        }
        else
        {
            Debug.LogError("Map�� SpriteRenderer�� �����ϴ�. SpriteRenderer�� �߰��ϼ���.");
        }
    }

    void Update()
    {
        // �÷��̾ ��� �Ʒ��� �������� ��ѱ� ���� ����
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
            SpawnPigeon(Vector2.up);    // �Ʒ� -> ��
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.down);  // �� -> �Ʒ�
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.left);  // ������ -> ����
            yield return new WaitForSeconds(spawnInterval);

            SpawnPigeon(Vector2.right); // ���� -> ������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnPigeon(Vector2 direction)
    {
        Vector3 spawnPosition = Vector3.zero; // ��ѱ� ���� ��ġ
        Vector3 targetPosition = Vector3.zero; // ��ѱⰡ ���ư��� ��ǥ ��ġ

        // ���⺰�� ���� ��ġ�� ��ǥ ��ġ ���
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

        // ��ѱ� ����
        GameObject pigeon = Instantiate(pigeonPrefab, spawnPosition, Quaternion.identity);

        // ��ѱⰡ ��ǥ ��ġ�� �̵��ϵ��� ����
        Rigidbody2D rb = pigeon.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("��ѱ� �����տ� Rigidbody2D�� �����ϴ�!");
            return;
        }

        rb.gravityScale = 0; // �߷� ����
        float speed = 5f; // ��ѱ� �ӵ�
        Vector3 directionToTarget = (targetPosition - spawnPosition).normalized; // ���� ���� ����ȭ
        rb.velocity = directionToTarget * speed; // ������ �ӵ��� ����

        // ��ѱ� ���� ó��
        pigeon.AddComponent<PigeonCleaner>().SetTarget(targetPosition);
    }
}