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

    public GameObject ui_dialogue; //말풍선
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
                            if (jihoon_B2.jihoonmove == 1)// 지훈이를 데려간다면 
                            {
                                dialogueid = 26;
                                //재화차감
                                Player.moveflag = 1;
                                //moveflag 다시 1
                                GameManager.instance.RemoveGold(1500);
                                if (!GameManager.instance.nomoney)
                                {
                                    saveflag = true; // 돈 있으면 세이브 완료
                                }
                                else // 없으면 save 불가 
                                {
                                    Vector3 currentPosition = player.transform.position;

                                    // X축으로 +0.5만큼 이동
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

                            // Y축으로 +0.5만큼 이동
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
            if (gameObject.name == "개찰구" && gointer == 0)
            {
                
                pos = transform.position;
                interobj = "개찰구";
                Player.moveflag = 0;
                talksqu.SetActive(true);
                options.SetActive(true);
                button.SetActive(false);
                who.text = customize.playername;
                content.text = "이동할까?";
                option1.text = "> 태그를 찍는다.";
                option2.text = "> 태그를 찍지 않는다.";

                Debug.Log("텍스트가 설정되었습니다: " + content.text);
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
        // 대화 매니저의 chooseFlag 값을 확인
        int choice = DialogueManager.instance.chooseFlag;
        Debug.Log("선택된 플래그: " + choice);

        if (interobj == "개찰구")
        {
            if (choice == 1)
            {
                SaveUI.SetActive(true);
                // 태그를 찍는다
                Player.moveflag = 1;
                button.SetActive(true);
                gointer = 1;
                Player.playertrans(transform.position.x - 3, transform.position.y);
                Debug.Log("플래그 1: 태그를 찍었다.");
            }
            else if (choice == 2)
            {
                Player.playertrans(pos.x + 1, pos.y); // 플레이어 이동 확인용 디버그
                Debug.Log("플레이어 이동: " + pos.x + 1 + ", " + pos.y);
                Player.moveflag = 1;
                button.SetActive(true);
                Debug.Log("플래그 2: 태그를 찍지 않았다.");
            }
            else
            {
                Debug.LogWarning("유효하지 않은 선택지");
            }
        }

        // 옵션 UI를 비활성화하고 선택이 완료되었음을 표시
        options.SetActive(false);
        talksqu.SetActive(false);

        if (DialogueManager.instance != null)
        {
            if (DialogueManager.instance.currentIdx < DialogueManager.instance.contextList.Length - 1)
            {
                DialogueManager.instance.onClickNextButton();  // 선택 후 대화 진행
            }
            else
            {
                Debug.Log("대화가 끝났습니다.");
                Player.moveflag = 1;  // 대화가 끝났으면 플레이어 움직임 활성화
            }
        }
        else
        {
            Debug.LogError("DialogueManager 인스턴스가 존재하지 않습니다.");
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
        if (interobj == "개찰구")
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

         if (interobj=="개찰구") //이 부분이 제 코드와 충돌이 있어서 살짝 수정했습니다 !
         {
             // 선택지 처리
             if (DialogueManager.instance.chooseFlag > 0)
             {
                 //ProcessChoice();  // 선택지에 따른 처리
                 DialogueManager.instance.chooseFlag = 0;  // 처리 후 플래그 초기화
             }
         }


     }*/
}