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
        //���� ������ ������ �� (�ٺ��� �����ðŶ�)
        string[] data = csvData.text.Split(new char[]{'\n'});
        
        for(int i = 1;i<data.Length;) //���� ������ 1���� ���� 
        {
            string[] row = data[i].Split(new char[] { ',' }); //id, ĳ����, ��纰�� �� 

            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����
            dialogue.name = row[1];
            Debug.Log(row[1]);

            List<string> contextList = new List<string>();

            do{
                contextList.Add(row[2]);
                Debug.Log(row[2]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == ""); //���� ���� null������ ����

            dialogue.contexts = contextList.ToArray();
            dialogueList.Add(dialogue); //ĳ���Ϳ� ����� ������ ���� 

            
        }
        return dialogueList.ToArray();
    }

}
