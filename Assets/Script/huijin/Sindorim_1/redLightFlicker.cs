using System.Collections;
using UnityEngine;

public class RedLightFlicker : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 3; //dialogue 시작 아이디

    public SpriteRenderer spriteRenderer;  // 스프라이트 렌더러
    public float minAlpha = 0.0f;  // 최소 투명도
    public float maxAlpha = 0.8f;  // 최대 투명도
    public float flickerSpeed = 1.0f;  // 깜빡이는 속도

    private float targetAlpha;  // 목표 알파 값
    private float alphaChangeRate;  // 알파 값 변화 비율

    void Start()
    {
        //csv파일 로드 //추후 주석처리 가능
        DataManager.instance.csv_FileName = "Sindorim_1";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        //초기 목표 알파 값 설정
        targetAlpha = maxAlpha;
        alphaChangeRate = flickerSpeed * Time.deltaTime;  //알파 변화 비율 초기화
    }

    void Update()
    {
        // 알파 값 변경
        Color color = spriteRenderer.color;
        color.a = Mathf.MoveTowards(color.a, targetAlpha, alphaChangeRate);
        spriteRenderer.color = color;

        // 알파 값이 목표값에 도달했는지 확인
        if (Mathf.Approximately(color.a, targetAlpha))
        {
            // 목표 알파 값을 전환
            targetAlpha = (targetAlpha == maxAlpha) ? minAlpha : maxAlpha;
        }
    }

    //충돌시 자동연출 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(AutoEvent());
            //이벤트는 한 번만 일어남
            GetComponent<Collider2D>().enabled = false;

        }
    }

    private IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(3, 4);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
