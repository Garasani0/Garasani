using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B2 : MonoBehaviour
{
    public Dialogue[] contextList;
    public bool line4 = false;
    public bool line3 = false;

    public IEnumerator ChungmuroB2_1()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        while (inSubway_0.instance.dialogueID < 24)
        {
            switch (inSubway_0.instance.dialogueID)
            {

                case (19):
                    contextList = DataManager.instance.GetDialogue(38, 39);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        inSubway_0.instance.dialogueID = 20;
                        line4 = true; //4호선 선택
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        inSubway_0.instance.dialogueID = 21;
                        line3 = true; //3호선 선택 
                    } 
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (20):
                    contextList = DataManager.instance.GetDialogue(40,40);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 21;
                    break;

                case (21):
                    contextList = DataManager.instance.GetDialogue(41, 41);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 21;
                    break;

                case (22):
                    contextList = DataManager.instance.GetDialogue(42, 43);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 23;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 24;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (23):
                    contextList = DataManager.instance.GetDialogue(44, 44);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 24;
                    break;

                case (24):
                    contextList = DataManager.instance.GetDialogue(45, 48);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 25;
                    break;

                default:
                    inSubway_0.instance.dialogueID = 25;
                    break;
            }

        }

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    public void ChooseLine4()
    {
        //4호선 승강장으로 다시 이동
        Debug.Log("4호선 승강장 이동");
        SceneManager.LoadScene("Chungmuro_B3");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}