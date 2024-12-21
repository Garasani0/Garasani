using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcdangsan1 : MonoBehaviour
{
    public int helpCount = 0;
    public static NPCdangsan instance;//��������

    public GameObject ui_dialogue; //��ǳ��
    public Dialogue[] contextList;

    // Start is called before the first frame update
    void Update()
    {

    }


    void Start()
    {

        ui_dialogue.SetActive(false);
        DataManager.instance.csv_FileName = "dangsanB1";
        DataManager.instance.DialogueLoad(); // CSV ���� �ε�
        Debug.Log("csv load");
        Player.moveflag = 1;
        customize.sceneflag = 4;




    }




    void OnMouseDown()
    {

        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }



    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        switch (gameObject.name)
        {


            case "�̰���":
                contextList = DataManager.instance.GetDialogue(1, 1);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "����ȣ":
                contextList = DataManager.instance.GetDialogue(2, 2);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "�Źٶ�":
                contextList = DataManager.instance.GetDialogue(3, 5);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "��â��":
                contextList = DataManager.instance.GetDialogue(3, 5);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;



            case "���� 1":
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "���� 2":
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "���� 3":
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;




            default: break;
        }
        ui_dialogue.SetActive(false);
    }
}
