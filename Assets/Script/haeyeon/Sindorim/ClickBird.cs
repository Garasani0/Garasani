using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBird : MonoBehaviour
{
    public GameObject chat;
    public GameObject player;
    public float interactionDistance = 2f;

    void Start()
    {
        chat.SetActive(false);
    }

    void OnMouseDown()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

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
