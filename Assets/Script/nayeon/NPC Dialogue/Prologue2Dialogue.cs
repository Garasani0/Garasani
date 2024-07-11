using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    private int currentDialogueIndex = 0; // ���� ��� �ε����� �����ϴ� ����
    private Dialogue[] contextList; // ��ȭ ������ �����ϴ� �迭
    private int currentContextIndex = 0; // ���� ���� �ε����� �����ϴ� ����

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void onClickNextButton()
    {
        if (contextList != null && currentDialogueIndex < contextList.Length)
        {
            DisplayDialogue(currentDialogueIndex, currentContextIndex);
            currentContextIndex++; // ���� �������� �̵�

            if (currentContextIndex >= contextList[currentDialogueIndex].contexts.Length)
            {
                currentContextIndex = 0; // ���� �ε����� �ʱ�ȭ
                currentDialogueIndex++; // ���� ���� �̵�
            }
        }
        else
        {
            // ��ȭ�� ���� ��� ��ȭâ �� 
            DialogueOnOff.instance.ui_Dialogue.SetActive(false);
        }
    }

    public IEnumerator Prologue2()
    {
        contextList = DataManager.instance.GetDialogue(1, 7); // ��ȭ ���� ��������
        currentDialogueIndex = 0; // ��ȭ ���� �� �ε��� �ʱ�ȭ
        currentContextIndex = 0; // ���� �ε��� �ʱ�ȭ
        if (contextList.Length > 0)
        {
            DisplayDialogue(currentDialogueIndex, currentContextIndex);
        }
        yield break;

    }

    public string nameCheck(string name)
    {
        if (name.CompareTo("player") == 0) //���ΰ��� ��� �̸��� �ٲ��ش�.
        {
            name = customize.playername;
        }
        return name;
    }

    //public void Pro_id1()
    //{
    //    Dialogue[] contextList  = DataManager.instance.GetDialogue(1, 7);
    //    for(int i = 0; i < contextList.Length; i++)
    //    {
    //        name.text = nameCheck(contextList[i].name); //���ΰ����� npc���� ����
    //        string dialogueText = "";
    //        foreach (string context in contextList[i].contexts)
    //        {
    //            dialogueText += context + "\n"; // �� ������ �ٹٲ����� ����
    //        }
    //        dialogue_text.text = dialogueText;
    //        Debug.Log(name.text);
    //        Debug.Log(dialogue_text.text);
    //    }
    //}

    private void DisplayDialogue(int dialogueIndex, int contextIndex)
    {
        if (dialogueIndex < contextList.Length && contextIndex < contextList[dialogueIndex].contexts.Length)
        {
            name.text = nameCheck(contextList[dialogueIndex].name); // ���ΰ����� NPC���� ����
            dialogue_text.text = contextList[dialogueIndex].contexts[contextIndex];
            Debug.Log(name.text);
            Debug.Log(dialogue_text.text);
        }
    }

    //public void Pro_id2()
    //{

    //}
    //public void Pro_id3()
    //{

    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
