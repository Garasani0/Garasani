using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour
{
    public Transform ground;
    public float npcSpeed = 2f;
    private float minX;
    private float maxX;
    private float npcWidth;

    private bool movingRight = true;

    void Start()
    {
        SetBoundaries();

        npcWidth = GetComponent<Renderer>().bounds.size.x;
    }

    void Update()
    {
        MoveNPC();
    }

    void SetBoundaries()
    {
        Bounds groundBounds = ground.GetComponent<Renderer>().bounds;

        minX = groundBounds.min.x;
        maxX = groundBounds.max.x;
    }

    void MoveNPC()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * npcSpeed * Time.deltaTime);

            if (transform.position.x + npcWidth / 2 >= maxX)
            {
                movingRight = false;
            }
        }

        else
        {
            transform.Translate(Vector2.left * npcSpeed * Time.deltaTime);

            if (transform.position.x - npcWidth / 2 <= minX)
            {
                movingRight = true;
            }
        }
    }
}