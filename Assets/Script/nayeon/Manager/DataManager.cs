using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance; //������ ������

    [SerializeField] string csv_FileName;

    //�ε����� �´� dialogue�� ���������� ��ųʸ� 
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    public static bool isFinish = false; //�����Ͱ� ���� ����Ǿ�����

    private void Awake()
    {
        if(instance == null)//��� �����͸� ��ųʸ��� �ֱ� 
        {
            instance = this; //�ڱ� �ڽ� �ֱ� -> ��ϵ� �����Ͱ� ���� instance�� �� 
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName); //�迭 Ÿ������ ���ϵȰ� ���� -> ��� �����Ͱ� ��� 

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        for(int i=0 ; i<= _EndNum-_StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]); //��ųʸ����� �������� 
        }

        return dialogueList.ToArray();
    }
}
