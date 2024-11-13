using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMovement : MonoBehaviour
{
    private float mapEndY;
    public float speed = 2f;

    public void SetMapEndY(float endY)
    {
        mapEndY = endY;
    }

    void Update()
    {
        // y 축으로 위로만 이동
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
        transform.position = targetPosition;

        // 맵 위 끝에 도달하면 오브젝트 삭제
        if (transform.position.y > mapEndY)
        {
            Destroy(gameObject);
        }
    }
}