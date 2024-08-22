using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingmanager : MonoBehaviour
{
  
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // ������ ������Ʈ���� �տ� �ִ��� Ȯ��
        Vector2 playerTransform = new Vector2(player.transform.position.x,player.transform.position.y);
        if (playerTransform.y > transform.position.y)
        {
            spriteRenderer.sortingOrder = 8; // ������ ������Ʈ �ڿ� ���� ��
        }
        else
        {
            spriteRenderer.sortingOrder = 4; // ������ ������Ʈ �տ� ���� ��
        }
    }
}
