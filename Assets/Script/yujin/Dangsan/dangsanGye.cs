using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangsanGye : MonoBehaviour
{
    public GameObject ui_dialogue; // 말풍선 UI
    public Dialogue[] contextList; // 대화 내용
    private int dialogueID = 1;
    private bool hasInteracted = false; // 일회성 처리 플래그

    void Start()
    { 
        ui_dialogue.SetActive(false);
        DataManager.instance.csv_FileName = "dangsan2F";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
    }

    // 플레이어가 Trigger 범위에 들어왔을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasInteracted && collision.CompareTag("Player")) // Player 태그 확인
        {
            hasInteracted = true; // 대화가 발생했음을 표시
            StartCoroutine(StartDialogue());
        }
    }

    /*void OnMouseDown()
    {

        Debug.Log("NPC clicked " + gameObject.name);
        StartCoroutine(GyeDial());
    }
    */
    // 대화 시작 코루틴
    private IEnumerator StartDialogue()
    {
        Debug.Log(dialogueID);
        Debug.Log("코루틴 시작");
        ui_dialogue.SetActive(true);

        while (dialogueID < 7)
        {
            Debug.Log("Current dialogueID: " + dialogueID);
            switch (dialogueID)
            {
                case (1):
               
                    contextList = DataManager.instance.GetDialogue(1, 1);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 2;
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 3;
                    }
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (2):
                    contextList = DataManager.instance.GetDialogue(2, 2);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.clickFlag);
                    DialogueManager.instance.clickFlag = false;
                    dialogueID = 4;
                    
                    break;

                case (3):
                    contextList = DataManager.instance.GetDialogue(3, 4);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.clickFlag);
                    DialogueManager.instance.clickFlag = false;
                    dialogueID = 4;
                    
                    break;

                case (4):
                    contextList = DataManager.instance.GetDialogue(4, 5);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 6;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 6;
                    else if (DialogueManager.instance.chooseFlag == 3)
                        dialogueID = 6;
                    else if (DialogueManager.instance.chooseFlag == 4)
                        dialogueID = 7;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (6):
                    contextList = DataManager.instance.GetDialogue(6, 6);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 6;
                    break;

                case (7):
                    contextList = DataManager.instance.GetDialogue(7, 7);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 7;
                    break;

                default:
                    
                    break;

            }
        }
        dialogueID = 0; 
        ui_dialogue.SetActive(false);

    }
    
}
