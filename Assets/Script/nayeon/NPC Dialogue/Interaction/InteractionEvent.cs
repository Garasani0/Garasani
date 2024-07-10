using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue; //Ŀ���� Ŭ���� ������ 

    //���� ��� ��ũ��Ʈ �������� 
    public Dialogue[] GetDialogue()
    {
        dialogue.dialouges = DataManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialouges;
    }
}
