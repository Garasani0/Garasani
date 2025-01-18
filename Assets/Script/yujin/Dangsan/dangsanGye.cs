using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class DangsanGye : MonoBehaviour
{
    public Item item;  // ���� ������ ������
    public GameObject ui_dialogue; // ��ǳ�� UI
    public Dialogue[] contextList; // ��ȭ ����
    private int dialogueID = 1;
    private bool hasInteracted = false; // ��ȸ�� ó�� �÷���
    private bool hasGivenItem = false; // �������� �̹� �־����� üũ�ϴ� ����


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
        if (collision.CompareTag("Player")) // Player �±� Ȯ�� 
        {
            if(hasInteracted==false)
            {
              
                hasInteracted = true; // ��ȭ�� �߻������� ǥ��
                StartCoroutine(StartDialogue());
            }

          
        }
    }
    void Update()
    {
        //Debug.Log(dialogueID);   
    }

    void OnMouseDown()
    {

        Debug.Log("NPC clicked " + gameObject.name);
      
    }
    
    // ��ȭ ���� �ڷ�ƾ
    private IEnumerator StartDialogue()
    {
        Debug.Log(dialogueID);
        Debug.Log("�ڷ�ƾ ����");
        ui_dialogue.SetActive(true);

        while (dialogueID < 8)
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
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 3;

                    break;
                case (3):
                    contextList = DataManager.instance.GetDialogue(3, 4);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 4;
                    break;
                case (4):
                    contextList = DataManager.instance.GetDialogue(5, 5);
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
                    dialogueID = 8;

                    if (!hasGivenItem)
                    {
                        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
                        if (inventoryManager != null)
                        {
                            inventoryManager.AddItemToSlot(item); // �������� �κ��丮�� �߰�
                            Debug.Log($"������ {item.itemName} ȹ��!");
                            hasGivenItem = true; // �������� �־��ٴ� �÷��� ����
                        }
                    }

                    break;

                case (7):
                    contextList = DataManager.instance.GetDialogue(7, 7);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 8;

                   
                    break;
                case (8):
                    
                    break;


                    break;

                default:

                    break;





            }

        }
        ui_dialogue.SetActive(false);
    }

  
    
}
