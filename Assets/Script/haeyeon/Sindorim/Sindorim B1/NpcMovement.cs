using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public GameObject map; // 맵 오브젝트를 드래그해서 할당
    public float speed = 5f; // 이동 속도

    private float minX; // 맵의 왼쪽 경계
    private float maxX; // 맵의 오른쪽 경계
    private float npcWidth; // NPC의 반 너비
    private int direction = 1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)

    void Start()
    {
        if (map == null)
        {
            Debug.LogError("맵 오브젝트를 할당하세요!");
            return;
        }

        // 맵의 Collider 기준으로 경계 계산
        BoxCollider2D mapCollider = map.GetComponent<BoxCollider2D>();
        if (mapCollider != null)
        {
            minX = mapCollider.bounds.min.x; // 맵의 왼쪽 경계
            maxX = mapCollider.bounds.max.x; // 맵의 오른쪽 경계
        }
        else
        {
            Debug.LogError("맵 오브젝트에 BoxCollider2D가 없습니다!");
        }

        // NPC의 Collider 기준으로 크기 계산
        BoxCollider2D npcCollider = GetComponent<BoxCollider2D>();
        if (npcCollider != null)
        {
            npcWidth = npcCollider.bounds.extents.x; // NPC의 반 너비
        }
        else
        {
            Debug.LogError("NPC 오브젝트에 BoxCollider2D가 없습니다!");
        }
    }

    void Update()
    {
        // NPC 이동
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        // NPC가 경계를 벗어나려 하면 방향 전환 및 위치 보정
        if (transform.position.x - npcWidth <= minX)
        {
            direction = 1; // 오른쪽으로 이동
            ClampPosition(); // 경계에서 위치 보정
        }
        else if (transform.position.x + npcWidth >= maxX)
        {
            direction = -1; // 왼쪽으로 이동
            ClampPosition(); // 경계에서 위치 보정
        }
    }

    // NPC가 맵 경계를 넘어갔을 경우 위치를 보정
    void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX + npcWidth, maxX - npcWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}