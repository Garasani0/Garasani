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
        // ��ѱⰡ ��ǥ ��ġ�� �����ϸ� ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}