using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layercontroller : MonoBehaviour
{

    private Vector2 playertrans;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            Vector2 playertrans = new Vector2(player.transform.position.x,
                                player.transform.position.y);
            if (playertrans.y > transform.position.y)
            {
                spriteRenderer.sortingOrder = 8; // ������ ������Ʈ �ڿ� ���� ��
            }
            else
            {
                spriteRenderer.sortingOrder = 5; // ������ ������Ʈ �տ� ���� ��
            }


        }
       
        
        
        
    }
}
