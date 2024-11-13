using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject player; // Player 오브젝트
    public float interactionDistance = 2f; // Player와의 상호작용 거리
    private int clickCount = 0; // 자판기를 누른 횟수

    void Start()
    {
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
            clickCount++; // 자판기 클릭 횟수 증가

            // 클릭 횟수에 따라 대화 ID 설정
            if (clickCount == 3)
            {
                StartCoroutine(StartDialogue(8)); // 세 번째 클릭 시 ID=8 대화 시작
                clickCount = 0; // 클릭 횟수 초기화
            }
            else
            {
                StartCoroutine(StartDialogue(7)); // 세 번째가 아닌 경우 ID=7 대화 시작
            }
        }
        else
        {
            Debug.Log("Player가 너무 멀리 있습니다. 상호작용할 수 없습니다.");
        }
    }

    private IEnumerator StartDialogue(int dialogueID)
    {
        // 대화 UI 활성화
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // 지정된 ID의 대화 내용을 불러옴 (선택지가 없음)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        // 대화가 끝나면 UI 비활성화
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
