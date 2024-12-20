using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 6; // dialogue 시작 아이디

    private void OnMouseDown()
    {
        Debug.Log("오브젝트가 클릭되었습니다!");
        StartCoroutine(AutoEvent());
    }

    private void Start()
    {
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
    }

    public IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
