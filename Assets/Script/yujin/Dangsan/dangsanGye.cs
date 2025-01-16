using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangsanGye : MonoBehaviour
{
    public GameObject ui_dialogue; // ��ǳ�� UI
    public Dialogue[] contextList; // ��ȭ ����
    private int dialogueID = 1;
    private bool hasInteracted = false; // ��ȸ�� ó�� �÷���

    void Start()
    { 
        ui_dialogue.SetActive(false);
        DataManager.instance.csv_FileName = "dangsan2F";
        DataManager.instance.DialogueLoad(); // CSV ���� �ε�
        Debug.Log("csv load");
    }

    // �÷��̾ Trigger ������ ������ ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasInteracted && collision.CompareTag("Player")) // Player �±� Ȯ��
        {
            hasInteracted = true; // ��ȭ�� �߻������� ǥ��
            StartCoroutine(StartDialogue());
        }
    }

    /*void OnMouseDown()
    {

        Debug.Log("NPC clicked " + gameObject.name);
        StartCoroutine(GyeDial());
    }
    */
    // ��ȭ ���� �ڷ�ƾ
    private IEnumerator StartDialogue()
    {
        Debug.Log(dialogueID);
        Debug.Log("�ڷ�ƾ ����");
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
