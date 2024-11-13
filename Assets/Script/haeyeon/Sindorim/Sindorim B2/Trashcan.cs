using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject player; // Player 오브젝트
    public float interactionDistance = 2f; // Player와의 상호작용 거리

    void Start()
    {
        // 처음에는 말풍선을 비활성화

        // 이 씬의 대화에 필요한 CSV 파일을 불러옴
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("SindorimB1B2 CSV 파일 불러오기 완료");
    }

    void OnMouseDown()
    {
        // Player와 스프라이트 간의 거리 계산
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // 일정 거리 안에 있을 때만 대화 시작
        if (distance <= interactionDistance)
        {
            StartCoroutine(StartDialogueWithChoices(9)); // ID=9의 선택지 있는 대화 시작
        }
        else
        {
            Debug.Log("Player가 너무 멀리 있습니다. 상호작용할 수 없습니다.");
        }
    }

    private IEnumerator StartDialogueWithChoices(int dialogueID)
    {
        // 대화 UI 활성화
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // 지정된 ID의 대화 내용을 불러옴 (선택지 있음)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        DialogueManager.instance.processChoose(contextList); // 선택지 대화 시작
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0); // 선택이 될 때까지 대기

        // 선택 결과에 따라 다음 대화 ID 결정
        if (DialogueManager.instance.chooseFlag == 1)
        {
            yield return StartCoroutine(StartDialogue(10)); // 첫 번째 선택지를 선택하면 ID=10으로 이동
        }
        else if (DialogueManager.instance.chooseFlag == 2)
        {
            yield return StartCoroutine(StartDialogue(11)); // 두 번째 선택지를 선택하면 ID=11으로 이동
        }

        // 선택지 플래그 초기화 및 대화 UI 비활성화
        DialogueManager.instance.chooseFlag = 0;
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    private IEnumerator StartDialogue(int dialogueID)
    {
        // 지정된 ID의 대화 내용을 불러옴 (선택지 없음)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    }
}
