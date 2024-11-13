using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReduce : MonoBehaviour
{
    private Health health; // PlayerHealth 스크립트 참조

    void Start()
    {
        // 충돌이 일어나는 오브젝트에 Health 컴포넌트가 있는지 확인
        health = GetComponent<Health>();

        if (health == null)
        {
            Debug.LogError("Health 컴포넌트가 이 오브젝트에 없습니다!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "NPC") // 떠돌아다니는 사람들에게 Tag를 "NPC"로 설정
        {
            if (health != null) // Health 컴포넌트가 제대로 초기화되었는지 확인
            {
                health.TakeDamage(5); // 피를 5만큼 깎음
                Debug.Log("충돌 발생! NPC로부터 데미지를 입음.");
            }
        }
    }
}

