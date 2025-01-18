using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBin : MonoBehaviour
{
    public Item item;  // 주울 아이템 데이터
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    private int dialogueID = 1;
    private bool hasClicked = false; // 클릭 여부 체크 변수

    private void OnMouseDown()
    {
        if (hasClicked) return; // 이미 클릭한 경우 반응하지 않음

        hasClicked = true; // 첫 번째 클릭 시 반응하도록 설정

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
            case "분리수거통":
                contextList = DataManager.instance.GetDialogue(36, 36);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            case "신문함":
                contextList = DataManager.instance.GetDialogue(37, 37);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            default: break;
        }
        ui_dialogue.SetActive(false);


    }
}