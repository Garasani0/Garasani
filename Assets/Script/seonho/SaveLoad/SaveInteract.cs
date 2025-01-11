using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveInteract : MonoBehaviour
{
    /*public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public GameObject options;

    private int gointer = 0;
    private string interobj;
    private Vector2 pos;*/

    public GameObject SaveUI;

    public GameObject ui_dialogue; //��ǳ��
    public GameObject player;
    public Dialogue[] contextList;
    private int dialogueid = 24;
    public static bool saveflag = false;


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player") && saveflag == false)
        {
            Debug.Log("Player entered the trigger zone!");
            Player.moveflag = 0;
            StartCoroutine(NpcRoutine());
        }
    }
    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        while (dialogueid < 26)
        {
            switch (dialogueid)
            {
                case 24:
                    if (saveflag == false)
                    {
                        

                        

                        contextList = DataManager.instance.GetDialogue(45, 45);
                        DialogueManager.instance.processChoose(contextList);
                        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                        if (DialogueManager.instance.chooseFlag == 1)
                        {
                            if (jihoon_B2.jihoonmove == 1)// �����̸� �������ٸ� 
                            {
                                dialogueid = 26;
                                //��ȭ����
                                Player.moveflag = 1;
                                //moveflag �ٽ� 1
                                GameManager.instance.RemoveGold(1500);
                                if (!GameManager.instance.nomoney)
                                {
                                    saveflag = true; // �� ������ ���̺� �Ϸ�
                                }
                                else // ������ save �Ұ� 
                                {
                                    Vector3 currentPosition = player.transform.position;

                                    // X������ +0.5��ŭ �̵�
                                    player.transform.position = new Vector3(currentPosition.x + 0.5f, currentPosition.y, currentPosition.z);
                                }
                            }
                            else
                            {
                                dialogueid = 25;
                            }
                        }
                        else if (DialogueManager.instance.chooseFlag == 2)
                        {
                            dialogueid = 26;

                            Player.moveflag = 1;
                            Vector3 currentPosition = player.transform.position;

                            // Y������ +0.5��ŭ �̵�
                            player.transform.position = new Vector3(currentPosition.x, currentPosition.y + 0.5f, currentPosition.z);

                        }

                        DialogueManager.instance.chooseFlag = 0;


                    }
                  

                    break;
                case 25:
                    contextList = DataManager.instance.GetDialogue(46, 46);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 26;
                    break;
                default:
                    dialogueid = 26;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        if (saveflag == false)
        {
            dialogueid = 24;
        }


    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            if (gameObject.name == "������" && gointer == 0)
            {
                
                pos = transform.position;
                interobj = "������";
                Player.moveflag = 0;
                talksqu.SetActive(true);
                options.SetActive(true);
                button.SetActive(false);
                who.text = customize.playername;
                content.text = "�̵��ұ�?";
                option1.text = "> �±׸� ��´�.";
                option2.text = "> �±׸� ���� �ʴ´�.";

                Debug.Log("�ؽ�Ʈ�� �����Ǿ����ϴ�: " + content.text);
            }
        }
    }

    private void ClearOptions()
    {
        option1.text = "";
        option2.text = "";
    }

    public void ProcessChoice()
    {
        // ��ȭ �Ŵ����� chooseFlag ���� Ȯ��
        int choice = DialogueManager.instance.chooseFlag;
        Debug.Log("���õ� �÷���: " + choice);

        if (interobj == "������")
        {
            if (choice == 1)
            {
                SaveUI.SetActive(true);
                // �±׸� ��´�
                Player.moveflag = 1;
                button.SetActive(true);
                gointer = 1;
                Player.playertrans(transform.position.x - 3, transform.position.y);
                Debug.Log("�÷��� 1: �±׸� �����.");
            }
            else if (choice == 2)
            {
                Player.playertrans(pos.x + 1, pos.y); // �÷��̾� �̵� Ȯ�ο� �����
                Debug.Log("�÷��̾� �̵�: " + pos.x + 1 + ", " + pos.y);
                Player.moveflag = 1;
                button.SetActive(true);
                Debug.Log("�÷��� 2: �±׸� ���� �ʾҴ�.");
            }
            else
            {
                Debug.LogWarning("��ȿ���� ���� ������");
            }
        }

        // �ɼ� UI�� ��Ȱ��ȭ�ϰ� ������ �Ϸ�Ǿ����� ǥ��
        options.SetActive(false);
        talksqu.SetActive(false);

        if (DialogueManager.instance != null)
        {
            if (DialogueManager.instance.currentIdx < DialogueManager.instance.contextList.Length - 1)
            {
                DialogueManager.instance.onClickNextButton();  // ���� �� ��ȭ ����
            }
            else
            {
                Debug.Log("��ȭ�� �������ϴ�.");
                Player.moveflag = 1;  // ��ȭ�� �������� �÷��̾� ������ Ȱ��ȭ
            }
        }
        else
        {
            Debug.LogError("DialogueManager �ν��Ͻ��� �������� �ʽ��ϴ�.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            interobj = null;
        }
    }

    public void buttondown()
    {
        if (interobj == "������")
        {
            talksqu.SetActive(false);
            interobj = null;
            ClearOptions();
            content.text = "";
        }
    }*/

   void Start()
    {
        //talksqu.SetActive(false);
        //options.SetActive(false);
        //button.SetActive(true);
        SaveUI.SetActive(false);

        customize.sceneflag = 2;
        Player.moveflag = 1;
        player = GameObject.Find("Player");

        if (player != null)
        {
            Debug.Log("Player object found!");
        }
        else
        {
            Debug.Log("Player object not found!");
        }

    }

    /* void Update()
     {

         if (interobj=="������") //�� �κ��� �� �ڵ�� �浹�� �־ ��¦ �����߽��ϴ� !
         {
             // ������ ó��
             if (DialogueManager.instance.chooseFlag > 0)
             {
                 //ProcessChoice();  // �������� ���� ó��
                 DialogueManager.instance.chooseFlag = 0;  // ó�� �� �÷��� �ʱ�ȭ
             }
         }


     }*/
}