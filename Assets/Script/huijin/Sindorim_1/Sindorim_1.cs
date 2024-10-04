using System.Collections;
using UnityEngine;

public class Sindorim_1 : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 1; //dialogue ���� ���̵�

    void Start()
    {
        //�÷��̾� �����̵��� �÷��� 
        customize.sceneflag = 4;
        customize.moveflag = 1;

        //���� ����ٴϵ���
        jihoon_B2.jihoonmove = 1;

        //CSV ���� �ε�
        DataManager.instance.csv_FileName = "Sindorim_1";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }

    //�ڵ��̺�Ʈ
    public IEnumerator AutoEvent()
    {
        Debug.Log(dialogueID);
        Debug.Log("�ڷ�ƾ ����");

        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(1, 2);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);


    }
}
