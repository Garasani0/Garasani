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
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
        transform.position = targetPosition;

        if (transform.position.y > mapEndY)
        {
            Destroy(gameObject);
        }
    }
}