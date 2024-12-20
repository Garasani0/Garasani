using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMoving : MonoBehaviour
{
    private Vector3 targetPosition;  // ��ǥ ��ġ
    private float speed;  // �̵� �ӵ�

    // �ʱ�ȭ �޼���
    public void Initialize(Vector3 target, float moveSpeed)
    {
        targetPosition = target;
        speed = moveSpeed;
    }

    void Update()
    {
        // ��ǥ ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            PigeonCleaner.CleanUp(this.gameObject);  // PigeonCleaner ȣ��
        }
    }
}