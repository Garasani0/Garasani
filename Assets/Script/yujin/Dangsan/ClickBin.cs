using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBin : MonoBehaviour
{
    public Item item;  // �ֿ� ������ ������
    public GameObject ui_dialogue; //��ǳ��
    public Dialogue[] contextList;
    private int dialogueID = 1;
    private bool hasClicked = false; // Ŭ�� ���� üũ ����

    private void OnMouseDown()
    {
        if (hasClicked) return; // �̹� Ŭ���� ��� �������� ����

        hasClicked = true; // ù ��° Ŭ�� �� �����ϵ��� ����

        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
            inventoryManager.AddItemToSlot(item);

        }

        StartCoroutine(BinRoutine());
    }

    public IEnumerator BinRoutine()
    {
        ui_dialogue.SetActive(true);
        switch (gameObject.name)
        {
            case "�и�������":
                contextList = DataManager.instance.GetDialogue(36, 36);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            case "�Ź���":
                contextList = DataManager.instance.GetDialogue(37, 37);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            default: break;
        }
        ui_dialogue.SetActive(false);


    }
}