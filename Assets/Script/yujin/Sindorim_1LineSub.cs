using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sindorim_1LineSub : MonoBehaviour
{
    public static Sindorim_1LineSub instance;
    public Dialogue[] contextList;
    //public Transform playerFirst; //��ġ ���� 
    public GameObject ui_dialogue;// ��ǳ��
    int dialogueID = 1;
   
 
    public GameObject player;
   
    
    public string nextSceneName; //��ȭ �� �ٷ� ���� ������ �̵��� �� �ֵ���
    private bool hasTriggered = false; //�÷��̾�� ���� �浹 ����
   


    public IEnumerator AutoEvent()
    {

        Debug.Log("����");
            ui_dialogue.SetActive(true);
            while (dialogueID < 4)
            {

                switch (dialogueID)
                {
                    case 1:
                        contextList = DataManager.instance.GetDialogue(1, 1);

                        DialogueManager.instance.processChoose(contextList);
                        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                        if (DialogueManager.instance.chooseFlag == 1)
                            dialogueID = 2;

                        else if (DialogueManager.instance.chooseFlag == 2)
                        {
                            dialogueID = 4;
                            Player.moveflag = 1;
                          

                        }

                        DialogueManager.instance.chooseFlag = 0;
                        break;
                    case 2:

                        contextList = DataManager.instance.GetDialogue(2, 4);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                        dialogueID = 3;
                        break;
                    case 3:
                        yield return new WaitForSeconds(1f);
                        SceneManager.LoadScene("Sindorim_1");
                      
                        dialogueID = 4;
                        break;


                    default:
                        dialogueID = 4;
                        break;

                }

            }
            ui_dialogue.SetActive(false);
        
        





        /*Debug.Log(inSubway_0.instance.dialogueID);  // ���� ��ȭ ID�� �α׷� ���
        DialogueManager.instance.ui_dialogue.SetActive(true);  // ��ȭ UI Ȱ��ȭ -> �̰� ��ȭ UI��ü�� �ƴմϴ�!

        contextList = DataManager.instance.GetDialogue(1, 4);
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);

        if (DialogueManager.instance.chooseFlag == 1)
            dialogueID = 2;

        else if (DialogueManager.instance.chooseFlag == 2)
            //dialogueID = 4;
            DialogueManager.instance.ui_dialogue.SetActive(false);

        DialogueManager.instance.chooseFlag = 0;

        DialogueManager.instance.ui_dialogue.SetActive(false);

        //��ȭ ���� �� 2�� ��
        yield return new WaitForSeconds(2f);
        // �� ��ȯ
        SceneManager.LoadScene(nextSceneName);*/
    }

    void Start()
    {
        DataManager.instance.csv_FileName = "sindorimtext";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        
        ui_dialogue.SetActive(false);
        customize.sceneflag = 4; //�׽�Ʈ ���� �ڵ� - ��������
        Player.moveflag = 1; // �׽�Ʈ ���� �ڵ� - ��������
        player = GameObject.Find("Player");




    }
    /*void Start()
    {
        DataManager.instance.csv_FileName = "<Sindorim_1LineSub>";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }*/

    /*private void OnTriggerEnter2D(Collider2D other) //�ƿ� �� ������ ������ �浹���� �� �ߵ��ǵ��� �ϱ� ���ؼ�
    {
        // Player �±׸� ���� ������Ʈ�� �浹�ϰ�, ���� Ʈ���ŵ��� ���� ���
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // �ߺ� ���� ����
            StartCoroutine(AutoEvent()); // ��ȭ �̺�Ʈ ����
        }
    }*/
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹 �߻�: " + other.gameObject.name); // �浹�� �߻��� ���� ������Ʈ �̸��� ���

        // �̸��� "Player"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        if (other.gameObject.name == "Player")
        {
           
            Debug.Log("�÷��̾�� �浹 ������!"); // �÷��̾�� �浹�� �����Ǿ����� ���
            StartCoroutine(AutoEvent());
            //Player.moveflag = 0;
            //StartCoroutine(FadeAndLoadScene());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        dialogueID = 1;
           
           
    }
}
