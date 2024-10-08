using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonHit : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();

        if (health == null)
        {
            Debug.LogError("Health 컴포넌트가 이 오브젝트에 없습니다!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pigeon")
        {
            if (health != null)
            {
                health.TakeDamage(health.currentHealth);
                Debug.Log("충돌 발생! NPC로부터 데미지를 입음.");
            }
        }
    }
}
