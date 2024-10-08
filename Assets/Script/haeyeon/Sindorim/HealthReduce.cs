using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReduce : MonoBehaviour
{
    private Health health; // PlayerHealth ��ũ��Ʈ ����

    void Start()
    {
        // �浹�� �Ͼ�� ������Ʈ�� Health ������Ʈ�� �ִ��� Ȯ��
        health = GetComponent<Health>();

        if (health == null)
        {
            Debug.LogError("Health ������Ʈ�� �� ������Ʈ�� �����ϴ�!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "NPC") // �����ƴٴϴ� ����鿡�� Tag�� "NPC"�� ����
        {
            if (health != null) // Health ������Ʈ�� ����� �ʱ�ȭ�Ǿ����� Ȯ��
            {
                health.TakeDamage(5); // �Ǹ� 5��ŭ ����
                Debug.Log("�浹 �߻�! NPC�κ��� �������� ����.");
            }
        }
    }
}

