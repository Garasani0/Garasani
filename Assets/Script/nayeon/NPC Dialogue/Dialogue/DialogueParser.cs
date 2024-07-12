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

            //Dialogue dialogue = new Dialogue(); //��ȭ ���� ����ִ� Dialogue ��ü ���� 


            //if(row[0] != null)
            //{
            //    dialogue.id = int.Parse(row[0]); //��ȭ ID 
            //}
            //else { dialogue.id = 0; }

            //if (row[1].CompareTo("���ΰ�") == 0)
            //    dialogue.name = customize.playername;
            //else
            //    dialogue.name = row[1]; //�̸�
            ////List<string> contextList = new List<string>(); //��� ����Ʈ

            ////��� ����Ʈ�� ��� �ֱ� 
            ////contextList.Add(row[2]);
            //dialogue.contexts = row[2];
            //if (row[3] != null)
            //{
            //    dialogue.chosen1 = row[3];
            //    dialogue.chosen1_ID = int.Parse(row[4]);
            //    dialogue.chosen2 = row[5];
            //    dialogue.chosen2_ID = int.Parse(row[6]);
            //}
            //else
            //{
            //    dialogue.chosen1 = "";
            //    dialogue.chosen1_ID = 0;
            //    dialogue.chosen2 = "";
            //    dialogue.chosen2_ID = 0;
            //}

            dialogueList.Add(dialogue); //����Ʈ�� �� ��ҿ� dialgoue ��ü ���� 
        }

        //do
        //{
        //    contextList.Add(row[2]);
        //    //Debug.Log(row[2]);
        //    if (++i < data.Length)
        //    {
        //        row = data[i].Split(new char[] { ',' });
        //    }
        //    else
        //    {
        //        break;
        //    }
        //} while (row[0].ToString() == ""); //���� ���� null������ ����


        //dialogue.contexts = contextList.ToArray();

        return dialogueList.ToArray();
    }

        
}

