using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonCleaner : MonoBehaviour
{
    private Vector3 targetPosition;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        // 비둘기가 목표 위치에 도달하면 삭제
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}