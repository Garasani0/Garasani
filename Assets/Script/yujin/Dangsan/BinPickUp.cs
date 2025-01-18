using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinPickUp : MonoBehaviour
{
    public List<Item> firstClickItems = new List<Item>(); // 첫 번째 클릭 시 얻을 아이템들
    public Item thirdClickItem; // 세 번째 클릭 시 얻을 아이템
    private int clickCount = 0; // 클릭 횟수

    public GameObject ui_dialogue; //말풍선
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
                case 1: //복권 3개 획득
                    foreach (Item item in firstClickItems)
                    {
                        dialogueid = 16;
                        StartCoroutine(NpcRoutine());
                        inventoryManager.AddItemToSlot(item);
                        Debug.Log($"첫 번째 클릭: {item.itemName} 획득");
                    }
                    break;

                case 2: //대사 출력

                    dialogueid = 17;
                    StartCoroutine(NpcRoutine());
                    Debug.Log("두 번째 클릭: 정민과의 대화");
                    break;

                case 3: // 부적 획득

                    dialogueid = 18;
                    StartCoroutine(NpcRoutine());
                    inventoryManager.AddItemToSlot(thirdClickItem);
                    Debug.Log($"세 번째 클릭: {thirdClickItem.itemName} 획득");
                    
                    break;

                default: // 클릭 횟수가 초과한 경우
                    Debug.Log("더 이상 클릭할 수 없습니다.");
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