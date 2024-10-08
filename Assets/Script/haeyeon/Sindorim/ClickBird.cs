using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBird : MonoBehaviour
{
    public GameObject chat;  // 말풍선 오브젝트
    public GameObject player;      // Player 오브젝트
    public float interactionDistance = 2f;  // Player와의 상호작용 거리

    void Start()
    {
        // 처음에는 말풍선을 비활성화
        chat.SetActive(false);
    }

    void OnMouseDown()
    {
        // Player와 스프라이트 간의 거리 계산
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // 일정 거리 안에 있을 때만 말풍선 활성화
        if (distance <= interactionDistance)
        {
            chat.SetActive(true);
        }
        else
        {
            Debug.Log("Player가 너무 멀리 있습니다. 상호작용할 수 없습니다.");
        }
    }
}
