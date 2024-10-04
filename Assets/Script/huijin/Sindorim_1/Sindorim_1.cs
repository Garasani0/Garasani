using System.Collections;
using UnityEngine;

public class Sindorim_1 : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 1; //dialogue 시작 아이디

    void Start()
    {
        //플레이어 움직이도록 플래그 
        customize.sceneflag = 4;
        customize.moveflag = 1;

        //지훈 따라다니도록
        jihoon_B2.jihoonmove = 1;

        //CSV 파일 로드
        DataManager.instance.csv_FileName = "Sindorim_1";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }

    //자동이벤트
    public IEnumerator AutoEvent()
    {
        Debug.Log(dialogueID);
        Debug.Log("코루틴 시작");

        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(1, 2);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);


    }
}
