using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private bool hasTriggered = false; // 한 번 실행 여부 확인
    public GameObject player; // 플레이어 오브젝트
    public Dialogue[] contextList;
    int dialogueID = 5; //dialogue 시작 아이디

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어와 충돌 시
        if (!hasTriggered && collision.gameObject == player)
        {
            hasTriggered = true; // 충돌 처리 플래그 설정
            StartCoroutine(AutoEvent()); // Dialogue 실행
        }
    }

    private void Start()
    {
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load 완료");

        // Start에서 AutoEvent 호출 제거
    }

    public IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}