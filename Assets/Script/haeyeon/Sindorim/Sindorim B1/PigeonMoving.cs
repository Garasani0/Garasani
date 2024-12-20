using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMoving : MonoBehaviour
{
    private Vector3 targetPosition;  // 목표 위치
    private float speed;  // 이동 속도

    // 초기화 메서드
    public void Initialize(Vector3 target, float moveSpeed)
    {
        targetPosition = target;
        speed = moveSpeed;
    }

    void Update()
    {
        // 목표 위치로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 목표 위치에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            PigeonCleaner.CleanUp(this.gameObject);  // PigeonCleaner 호출
        }
    }
}