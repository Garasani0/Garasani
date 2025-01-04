using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class sajunpc : MonoBehaviour
{
    public GameObject ui_dialogue; //��ǳ��
    public Dialogue[] contextList;
    public TMP_Text text;//�ؽ�Ʈ
    public static double sajuid = 20;
    public static bool ing = false;
    public static bool firstflag = true;
    public TMP_FontAsset hanjafont;
    public TMP_FontAsset originalFont;

    void Start()
    {
        customize.sceneflag = 4;
        Player.moveflag = 3;
        DataManager.instance.csv_FileName = "NPC";
        DataManager.instance.DialogueLoad(); // CSV ���� �ε�
        Debug.Log("csv load");
       



    }
   

    void OnMouseDown()
    {
        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }
    public IEnumerator NpcRoutine()
    {
       
        ui_dialogue.SetActive(true);
        while (sajuid < 40)
        {
            switch (sajuid)
            {
                case 20:
                    contextList = DataManager.instance.GetDialogue(65, 71);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 20.5;
                    break;
                case 20.5:
                    text.font = hanjafont;
                    // ������Ʈ ��� --> �������
                    contextList = DataManager.instance.GetDialogue(72, 72);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 20.7;
                    break;
                case 20.7:
                    text.font = originalFont;
                    contextList = DataManager.instance.GetDialogue(73, 73);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1 )
                    { //���� ���� ���� 
                      //�� ���� 
                        GameManager.instance.RemoveGold(5000);
                        if(!GameManager.instance.nomoney)
                        {
                            sajuid = 21;
                            firstflag = false;
                        }
                        else
                        {
                            sajuid = 40;
                        }
                    }
                    else 
                    { sajuid = 40; 
                    }
                    
                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 21:
                    contextList = DataManager.instance.GetDialogue(74, 74);
                    text.fontSize = 7;
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    text.fontSize = 3;
                    sajuid = 22;
                    break;
                case 22:
                    contextList = DataManager.instance.GetDialogue(75, 77);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = Random.Range(23, 35);
                    break;
                case 23:
                    contextList = DataManager.instance.GetDialogue(79, 83);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 24:
                    contextList = DataManager.instance.GetDialogue(85, 91);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 25:
                    contextList = DataManager.instance.GetDialogue(93, 98);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 26:
                    contextList = DataManager.instance.GetDialogue(100, 103);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 27:
                    contextList = DataManager.instance.GetDialogue(101, 109);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 28:
                    contextList = DataManager.instance.GetDialogue(111, 115);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 29:
                    contextList = DataManager.instance.GetDialogue(117, 123);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 30:
                    contextList = DataManager.instance.GetDialogue(125, 128);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 31:
                    contextList = DataManager.instance.GetDialogue(130, 134);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 32:
                    contextList = DataManager.instance.GetDialogue(136, 138);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 33:
                    contextList = DataManager.instance.GetDialogue(137, 145);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 34:
                    contextList = DataManager.instance.GetDialogue(147, 148);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 35:
                    contextList = DataManager.instance.GetDialogue(149, 154);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 36;
                    break;
                   
                case 36:
                    contextList = DataManager.instance.GetDialogue(155, 155);//�ʹٴ� ����
                    DialogueManager.delay = 0.05f;
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    DialogueManager.delay = 0.05f;
                    sajuid = 37;
                    break;
                case 37:
                    contextList = DataManager.instance.GetDialogue(156, 165);

                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        GameManager.instance.RemoveGold(10000);
                        if (!GameManager.instance.nomoney)
                        {
                            sajuid = 38;
                            firstflag = false;
                        }
                        else
                        {
                            sajuid = 39;
                        }
                       

                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        sajuid = 39;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                   
                case 38:
                    contextList = DataManager.instance.GetDialogue(166, 166);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 40;
                    break;
                case 39:
                    contextList = DataManager.instance.GetDialogue(167, 167);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 40;
                    break;
                default:
                    sajuid = 40;
                    break;

            }
            
           
        }

        ui_dialogue.SetActive(false);
        if (firstflag == true)
        {
            sajuid = 20;
        }





    }
}


