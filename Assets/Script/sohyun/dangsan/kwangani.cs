using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kwangani : MonoBehaviour
{
    public Sprite[] bodymove;
    SpriteRenderer spriteRenderer;
    private IEnumerator moveroutine;
    private bool coflag = true; // 코루틴 중복실행 방지 
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
        if(dangsanB1kwang.twoflag&&coflag)
        {
            StopCoroutine(moveroutine);
            StartCoroutine(move2());
        }
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
    private IEnumerator move2()
    {
        coflag = false;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            spriteRenderer.sprite = bodymove[2];

            yield return new WaitForSeconds(0.5f);
            spriteRenderer.sprite = bodymove[3];

        }
    }
}
