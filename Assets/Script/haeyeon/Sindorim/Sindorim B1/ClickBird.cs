using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBird : MonoBehaviour
{
    public GameObject player;  // Player 오브젝트
    public float interactionDistance = 2f;  // Player와의 상호작용 거리
    public Dialogue[] contextList;
    int dialogueID = 6; //dialogue 시작 아이디

    void Start()
    {
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(StartDialogue());
    }

    void OnMouseDown()
    {
        // Player와 스프라이트 간의 거리 계산
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // 일정 거리 안에 있을 때만 대화 시작
        if (distance <= interactionDistance)
        {
            StartCoroutine(StartDialogue());
        }
        else
        {
            Debug.Log("Player가 너무 멀리 있습니다. 상호작용할 수 없습니다.");
        }
    }

    private IEnumerator StartDialogue()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(6, 6);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
