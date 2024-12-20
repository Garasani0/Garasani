using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 1; //dialogue 시작 아이디
    void Start() 
    {

        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }

    public IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(1, 4);
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);

        if (DialogueManager.instance.chooseFlag == 1)
            dialogueID = 2;

        else if (DialogueManager.instance.chooseFlag == 2)
            dialogueID = 3;

        else if (DialogueManager.instance.chooseFlag == 3)
            dialogueID = 4;

        DialogueManager.instance.chooseFlag = 0;

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
