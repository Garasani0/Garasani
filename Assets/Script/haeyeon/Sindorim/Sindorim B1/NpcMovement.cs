using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public GameObject map; // �� ������Ʈ�� �巡���ؼ� �Ҵ�
    public float speed = 5f; // �̵� �ӵ�

    private float minX; // ���� ���� ���
    private float maxX; // ���� ������ ���
    private float npcWidth; // NPC�� �� �ʺ�
    private int direction = 1; // �̵� ���� (1: ������, -1: ����)

    void Start()
    {
        if (map == null)
        {
            Debug.LogError("�� ������Ʈ�� �Ҵ��ϼ���!");
            return;
        }

        // ���� Collider �������� ��� ���
        BoxCollider2D mapCollider = map.GetComponent<BoxCollider2D>();
        if (mapCollider != null)
        {
            minX = mapCollider.bounds.min.x; // ���� ���� ���
            maxX = mapCollider.bounds.max.x; // ���� ������ ���
        }
        else
        {
            Debug.LogError("�� ������Ʈ�� BoxCollider2D�� �����ϴ�!");
        }

        // NPC�� Collider �������� ũ�� ���
        BoxCollider2D npcCollider = GetComponent<BoxCollider2D>();
        if (npcCollider != null)
        {
            npcWidth = npcCollider.bounds.extents.x; // NPC�� �� �ʺ�
        }
        else
        {
            Debug.LogError("NPC ������Ʈ�� BoxCollider2D�� �����ϴ�!");
        }
    }

    void Update()
    {
        // NPC �̵�
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        // NPC�� ��踦 ����� �ϸ� ���� ��ȯ �� ��ġ ����
        if (transform.position.x - npcWidth <= minX)
        {
            direction = 1; // ���������� �̵�
            ClampPosition(); // ��迡�� ��ġ ����
        }
        else if (transform.position.x + npcWidth >= maxX)
        {
            direction = -1; // �������� �̵�
            ClampPosition(); // ��迡�� ��ġ ����
        }
    }

    // NPC�� �� ��踦 �Ѿ�� ��� ��ġ�� ����
    void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX + npcWidth, maxX - npcWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}