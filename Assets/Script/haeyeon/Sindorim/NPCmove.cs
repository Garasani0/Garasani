using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour
{
    public Transform ground;    // '[바닥]지하 2층' 오브젝트의 Transform
    public float npcSpeed = 2f; // NPC의 기본 이동 속도
    private float minX;         // 좌측 경계의 x 좌표
    private float maxX;         // 우측 경계의 x 좌표
    private float npcWidth;     // NPC의 가로 크기

    private bool movingRight = true;  // NPC가 우측으로 이동 중인지 여부

    void Start()
    {
        // '[바닥]지하 2층' 오브젝트의 좌우 경계를 계산
        SetBoundaries();

        // NPC의 가로 크기 계산 (Renderer를 통해 크기 가져옴)
        npcWidth = GetComponent<Renderer>().bounds.size.x;
    }

    void Update()
    {
        // NPC가 좌우로 움직이도록 설정
        MoveNPC();
    }

    void SetBoundaries()
    {
        // '[바닥]지하 2층'의 크기를 기반으로 좌우 경계 계산
        Bounds groundBounds = ground.GetComponent<Renderer>().bounds;

        minX = groundBounds.min.x;  // '[바닥]지하 2층'의 좌측 끝 x 좌표
        maxX = groundBounds.max.x;  // '[바닥]지하 2층'의 우측 끝 x 좌표
    }

    void MoveNPC()
    {
        // 우측으로 이동 중일 때
        if (movingRight)
        {
            transform.Translate(Vector2.right * npcSpeed * Time.deltaTime);

            // NPC의 오른쪽 경계가 maxX를 넘지 않도록 설정
            if (transform.position.x + npcWidth / 2 >= maxX)
            {
                movingRight = false;
            }
        }
        // 좌측으로 이동 중일 때
        else
        {
            transform.Translate(Vector2.left * npcSpeed * Time.deltaTime);

            // NPC의 왼쪽 경계가 minX를 넘지 않도록 설정
            if (transform.position.x - npcWidth / 2 <= minX)
            {
                movingRight = true;
            }
        }
    }
}