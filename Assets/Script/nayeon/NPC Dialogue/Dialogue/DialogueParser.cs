using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
   public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //��� ����Ʈ ���� 
        //�Ľ̵� �����͸� �ӽ÷� ����

        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //csv���� ������
        if (csvData == null)
        {
            Debug.LogError("CSV file not found: " + _CSVFileName);
            return dialogueList.ToArray();
        }

        
        string[] data = csvData.text.Split(new char[]{'\n'}); //���� ������ ������ �� (�ٺ��� �����ðŶ�)
        
        for(int i = 1;i<data.Length;i++) //���� ������ 1���� ���� 
        {
            string[] row = data[i].Split(new char[] { ',' }); //�� csv�������� ���� row array�� �Ҵ� 

            if (row.Length < 7)
            {
                Debug.LogWarning("Row does not have enough columns: " + data[i]);
                continue; // ���� �ٷ� �Ѿ
            }

            Dialogue dialogue = new Dialogue(); // ��ȭ ���� ����ִ� Dialogue ��ü ���� 

            if (!int.TryParse(row[0], out dialogue.id))
            {
                dialogue.id = 0; // �Ľ� ���� �� �⺻�� ����
            }

            if (row[1].CompareTo("���ΰ�") == 0)
                dialogue.name = customize.playername;
            else
                dialogue.name = row[1]; // �̸�

            dialogue.contexts = row[2]; // ��� ����

            dialogue.chosen1 = row[3]; // ������1

            if (!int.TryParse(row[4], out dialogue.chosen1_ID))
            {
                dialogue.chosen1_ID = 0; // �Ľ� ���� �� �⺻�� ����
            }

            dialogue.chosen2 = row[5]; // ������2

            if (!int.TryParse(row[6], out dialogue.chosen2_ID))
            {
                dialogue.chosen2_ID = 0; // �Ľ� ���� �� �⺻�� ����
            }

            dialogue.contexts = dialogue.contexts.Replace("`", ",");
            dialogue.chosen1 = dialogue.chosen1.Replace("`", ",");
            dialogue.chosen2 = dialogue.chosen2.Replace("`", ",");

            dialogueList.Add(dialogue); //����Ʈ�� �� ��ҿ� dialgoue ��ü ���� 
        }


        return dialogueList.ToArray();
    }

        
}

