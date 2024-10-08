using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReduce : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();

        if (health == null)
        {
            Debug.LogError("Health ������Ʈ�� �� ������Ʈ�� �����ϴ�!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "NPC")
        {
            if (health != null)
            {
                health.TakeDamage(5);
                Debug.Log("�浹 �߻�! NPC�κ��� �������� ����.");
            }
        }
    }
}

