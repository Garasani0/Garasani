using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinPickUp : MonoBehaviour
{
    public List<Item> firstClickItems = new List<Item>(); // ù ��° Ŭ�� �� ���� �����۵�
    public Item thirdClickItem; // �� ��° Ŭ�� �� ���� ������
    private int clickCount = 0; // Ŭ�� Ƚ��

    public GameObject ui_dialogue; //��ǳ��
    public Dialogue[] contextList;
    private int dialogueid = 16;

    private void OnMouseDown()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
            clickCount++;

            switch (clickCount)
            {
                case 1: //���� 3�� ȹ��
                    foreach (Item item in firstClickItems)
                    {
                        dialogueid = 16;
                        StartCoroutine(NpcRoutine());
                        inventoryManager.AddItemToSlot(item);
                        Debug.Log($"ù ��° Ŭ��: {item.itemName} ȹ��");
                    }
                    break;

                case 2: //��� ���

                    dialogueid = 17;
                    StartCoroutine(NpcRoutine());
                    Debug.Log("�� ��° Ŭ��: ���ΰ��� ��ȭ");
                    break;

                case 3: // ���� ȹ��

                    dialogueid = 18;
                    StartCoroutine(NpcRoutine());
                    inventoryManager.AddItemToSlot(thirdClickItem);
                    Debug.Log($"�� ��° Ŭ��: {thirdClickItem.itemName} ȹ��");
                    
                    break;

                default: // Ŭ�� Ƚ���� �ʰ��� ���
                    Debug.Log("�� �̻� Ŭ���� �� �����ϴ�.");
                    dialogueid= 19;
                    StartCoroutine(NpcRoutine());
                    break;
            }
        }
    }

    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        
            switch (dialogueid)
            {
                case 16:
                    contextList = DataManager.instance.GetDialogue(16, 16);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    
                    break;
                case 17:

                    contextList = DataManager.instance.GetDialogue(17, 17);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    
                    break;

                case 18:
                    contextList = DataManager.instance.GetDialogue(18, 18);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    
                    break;


                default:
                    
                    break;

            }


        

        ui_dialogue.SetActive(false);
        
    }
}