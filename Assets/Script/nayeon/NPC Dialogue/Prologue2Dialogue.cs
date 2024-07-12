using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    public TMP_Text chosen1_text;
    public TMP_Text chosen2_text;
    int currentIdx;
    string ChooseFlag = "";
    public int dialogueID;

    private Dialogue[] contextList; // ��ȭ ������ �����ϴ� �迭

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void prologue2()
    {
        while (dialogueID < 4)
        {
            dialogueID = 1;

            switch (dialogueID)
            {
                case (1):
                    pro_id1(DataManager.instance.GetDialogue(1, 7));
                    break;
                case (2):
                    pro_id2(DataManager.instance.GetDialogue(8, 8));
                    break;
                case (3):
                    pro_id2(DataManager.instance.GetDialogue(9, 9));
                    break;
            }
        }
        
    }
    public void onClickNextButton()
    {
        if (contextList != null && currentIdx < contextList.Length - 1)
        {
            currentIdx++; // ���� �������� �̵�
            DisplayDialogue();
        }
        else
        {
            Debug.Log("contextlist �ʱ�ȭ �ȵ�");
        }
    }

    public void OnClickChoose()
    {
        //�±װ� 1�̸� ��ȣ 1����, 2�� 2����
        ChooseFlag = EventSystem.current.currentSelectedGameObject.tag;
        
    }


    private void DisplayDialogue()
    {
        if (contextList == null || contextList.Length == 0 || currentIdx >= contextList.Length)
            return;

        dialogue_text.text = contextList[currentIdx].contexts;
        name.text = contextList[currentIdx].name;

        if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1))
        {
            chosen1_text.text = contextList[currentIdx].chosen1;
            chosen2_text.text = contextList[currentIdx].chosen2;
        }
        else
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
        }


    }


    public void pro_id1(Dialogue[] dialogues)
    {
        contextList = dialogues; // contextList �ʱ�ȭ
        currentIdx = 0; // �ε��� �ʱ�ȭ
        DisplayDialogue();
        if (ChooseFlag.CompareTo("chosen1") == 0)
            dialogueID = 2;
        else dialogueID = 3;
    }

    public void pro_id2(Dialogue[] dialogues)
    {
        contextList = dialogues; // contextList �ʱ�ȭ
        currentIdx = 0; // �ε��� �ʱ�ȭ
        DisplayDialogue();
        Debug.Log("id2");
    }
    public void pro_id3(Dialogue[] dialogues)
    {
        contextList = dialogues; // contextList �ʱ�ȭ
        currentIdx = 0; // �ε��� �ʱ�ȭ
        DisplayDialogue();
        Debug.Log("id3");
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
