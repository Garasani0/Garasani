using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour
{
    public Transform ground;    // '[�ٴ�]���� 2��' ������Ʈ�� Transform
    public float npcSpeed = 2f; // NPC�� �⺻ �̵� �ӵ�
    private float minX;         // ���� ����� x ��ǥ
    private float maxX;         // ���� ����� x ��ǥ
    private float npcWidth;     // NPC�� ���� ũ��

    private bool movingRight = true;  // NPC�� �������� �̵� ������ ����

    void Start()
    {
        // '[�ٴ�]���� 2��' ������Ʈ�� �¿� ��踦 ���
        SetBoundaries();

        // NPC�� ���� ũ�� ��� (Renderer�� ���� ũ�� ������)
        npcWidth = GetComponent<Renderer>().bounds.size.x;
    }

    void Update()
    {
        // NPC�� �¿�� �����̵��� ����
        MoveNPC();
    }

    void SetBoundaries()
    {
        // '[�ٴ�]���� 2��'�� ũ�⸦ ������� �¿� ��� ���
        Bounds groundBounds = ground.GetComponent<Renderer>().bounds;

        minX = groundBounds.min.x;  // '[�ٴ�]���� 2��'�� ���� �� x ��ǥ
        maxX = groundBounds.max.x;  // '[�ٴ�]���� 2��'�� ���� �� x ��ǥ
    }

    void MoveNPC()
    {
        // �������� �̵� ���� ��
        if (movingRight)
        {
            transform.Translate(Vector2.right * npcSpeed * Time.deltaTime);

            // NPC�� ������ ��谡 maxX�� ���� �ʵ��� ����
            if (transform.position.x + npcWidth / 2 >= maxX)
            {
                movingRight = false;
            }
        }
        // �������� �̵� ���� ��
        else
        {
            transform.Translate(Vector2.left * npcSpeed * Time.deltaTime);

            // NPC�� ���� ��谡 minX�� ���� �ʵ��� ����
            if (transform.position.x - npcWidth / 2 <= minX)
            {
                movingRight = true;
            }
        }
    }
}