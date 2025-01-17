using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inhosu : MonoBehaviour
{
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    private int dialogueid = 8;
    // Start is called before the first frame update
   
    void Start()
    {
        
    }
    void OnMouseDown()
    {  
      StartCoroutine(NpcRoutine());
    }
    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        while (dialogueid < 11)
        {
            switch (dialogueid)
            {
                case 8:
                    contextList = DataManager.instance.GetDialogue(10, 10);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 9;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 10;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 9:

                    contextList = DataManager.instance.GetDialogue(11, 11);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 11;
                    break;
                case 10:
                    contextList = DataManager.instance.GetDialogue(12, 13);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 11;
                    break;


                default:
                    dialogueid = 11;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        dialogueid = 8;// 다시 말걸 수 있도록
       


    }


    // Update is called once per frame

}
