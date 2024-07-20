using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    public TMP_Text chosen1_text;
    public TMP_Text chosen2_text;
    public TMP_Text chosen3_text;
    public int currentIdx;
    public bool IsDialogueFinished;
    public  Dialogue[] contextList;
    public int chooseFlag = 0;
    public bool clickFlag = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Initialize(Dialogue[] dialogues)
    {
        contextList = dialogues;
        currentIdx = 0;
        IsDialogueFinished = false;
        DisplayDialogue();
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
            IsDialogueFinished = true;
            Debug.Log("contextlist �ʱ�ȭ �ȵ�");
        }
    }

    public void DisplayDialogue()
    {
        if (contextList == null || contextList.Length == 0 || currentIdx >= contextList.Length)
            return;

        dialogue_text.text = contextList[currentIdx].contexts;
        name.text = contextList[currentIdx].name;

        if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1) && string.IsNullOrEmpty(contextList[currentIdx].chosen3))
        {
            chosen1_text.text = contextList[currentIdx].chosen1;
            chosen2_text.text = contextList[currentIdx].chosen2;
            chosen3_text.text = "";
        }
        else if(!string.IsNullOrEmpty(contextList[currentIdx].chosen3) && string.IsNullOrEmpty(contextList[currentIdx].chosen1))
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
            chosen3_text.text = contextList[currentIdx].chosen3;

        }
        else if(string.IsNullOrEmpty(contextList[currentIdx].chosen1) && string.IsNullOrEmpty(contextList[currentIdx].chosen3))
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
            chosen3_text.text = "";
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
        else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen3") == 0)
            clickFlag = true;
        Debug.Log("chooseFlag: " + chooseFlag + ", clickFlag: " + clickFlag);

    }

  

    public void processChoose(Dialogue[] dialogues) //�������� �ִ� ��ȭ�� ��� ��� 
    {
        Initialize(dialogues);
    }

    public IEnumerator processing(Dialogue[] dialogues) //�������� ���� ��ȭ�� ��� ��� 
    {
        Initialize(dialogues);
        yield return new WaitUntil(() => IsDialogueFinished);

    }

}
