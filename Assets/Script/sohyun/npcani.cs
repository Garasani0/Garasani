using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcani : MonoBehaviour //npc ���ڸ� �ִϸ��̼� ����ϴ� �ڵ� 
{
    public Sprite[] bodymove;
    SpriteRenderer spriteRenderer;
    private IEnumerator moveroutine;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bodymove[0];
        moveroutine = move();
        StartCoroutine(moveroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            
            spriteRenderer.sprite = bodymove[1];
         
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.sprite = bodymove[0];
            
        }
    }
}
