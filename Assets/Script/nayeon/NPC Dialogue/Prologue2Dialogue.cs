using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public int dialogueID;
    public int chooseFlag = 0;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void prologue2()
    {
        dialogueID = 1;
        //pro_id1(DataManager.instance.GetDialogue(1, 7));
        Debug.Log("start" + dialogueID);

        while (true)
        {
            if (dialogueID == 4) break;

            switch (dialogueID)
            {
                case (1):
                    pro_id1(DataManager.instance.GetDialogue(1, 7));
                    if (chooseFlag == 1)
                        dialogueID = 2; //���� ��ȭ ID
                    else if (chooseFlag == 2)
                        dialogueID = 3;
                    Debug.Log("id1 ������ " + dialogueID);
                    break;
                case (2):
                    pro_id2(DataManager.instance.GetDialogue(8, 8));
                    dialogueID = 4;
                    break;
                case (3):
                    pro_id3(DataManager.instance.GetDialogue(9, 9));
                    dialogueID = 4;
                    break;
                default:
                    break;
            }

            
        }
        
    }

    public void OnClickChoose()
    {
        Debug.Log("������ Ŭ�� Ȯ��");
        //�±װ� 1�̸� ��ȣ 1����, 2�� 2����
        if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
            chooseFlag = 1;
        else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0) 
            chooseFlag = 2;
        Debug.Log("Flag" + chooseFlag); ;
    }

    public void pro_id1(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        //if (chooseFlag == 1)
        //{
        //    dialogueID = 2; //���� ��ȭ ID
        //}
        //else if(chooseFlag == 2)
        //{
        //    dialogueID = 3;
        //}
        //Debug.Log("id1" + dialogueID);
        //prologue2(dialogueID);
    }

    public void pro_id2(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        Debug.Log("id2");
        //dialogueID = 4;
    }

    public void pro_id3(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        Debug.Log("id3");
        //dialogueID = 4;
    }



}
