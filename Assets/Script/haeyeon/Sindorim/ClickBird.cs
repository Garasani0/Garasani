using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBird : MonoBehaviour
{
    public GameObject chat;  // ��ǳ�� ������Ʈ
    public GameObject player;      // Player ������Ʈ
    public float interactionDistance = 2f;  // Player���� ��ȣ�ۿ� �Ÿ�

    void Start()
    {
        // ó������ ��ǳ���� ��Ȱ��ȭ
        chat.SetActive(false);
    }

    void OnMouseDown()
    {
        // Player�� ��������Ʈ ���� �Ÿ� ���
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // ���� �Ÿ� �ȿ� ���� ���� ��ǳ�� Ȱ��ȭ
        if (distance <= interactionDistance)
        {
            chat.SetActive(true);
        }
        else
        {
            Debug.Log("Player�� �ʹ� �ָ� �ֽ��ϴ�. ��ȣ�ۿ��� �� �����ϴ�.");
        }
    }
}
