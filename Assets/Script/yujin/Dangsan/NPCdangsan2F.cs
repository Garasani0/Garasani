using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCdangsan2F : MonoBehaviour
{
    public int helpCount = 0;
    public static NPCdangsan2F instance;//참조도움

    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    private int dialogueID = 1;

    // Start is called before the first frame update
    void Update()
    {
       
    }
   

    void Start()
    {

        ui_dialogue.SetActive(false);
        DataManager.instance.csv_FileName = "dangsan2F";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
        Player.moveflag = 1;
        customize.sceneflag = 4;
       

    }
    

   

    void OnMouseDown(){

        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }


    
    public IEnumerator NpcRoutine(){
        ui_dialogue.SetActive(true);
        switch (gameObject.name) {


            case "계환숙":
                contextList = DataManager.instance.GetDialogue(1, 1);
                DialogueManager.instance.processChoose(contextList);
                yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                if (DialogueManager.instance.chooseFlag == 1)
                { dialogueID = 2; }

                else if (DialogueManager.instance.chooseFlag == 2)
                { dialogueID = 3; }

                DialogueManager.instance.chooseFlag = 0;

                contextList = DataManager.instance.GetDialogue(4, 4);
                DialogueManager.instance.processChoose(contextList);
                yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                if (DialogueManager.instance.chooseFlag == 1)
                {
                    dialogueID = 5;
                }
                else if (DialogueManager.instance.chooseFlag == 2)
                {
                    dialogueID = 5;
                }
                else if (DialogueManager.instance.chooseFlag == 3)
                {
                    dialogueID = 5;
                }
                else if (DialogueManager.instance.chooseFlag == 4)
                {
                    dialogueID = 6;
                }
                else
                {
                    Debug.LogWarning("Unexpected chooseFlag value: " + DialogueManager.instance.chooseFlag);
                }
                DialogueManager.instance.chooseFlag = 0;

                break;


            case "오탁훈":
                contextList = DataManager.instance.GetDialogue(7, 7);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            case "나다빈":
                contextList = DataManager.instance.GetDialogue(7, 7);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

            case "인호수":

                contextList = DataManager.instance.GetDialogue(8, 8);
                DialogueManager.instance.processChoose(contextList);
                yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);


                if (DialogueManager.instance.chooseFlag == 1)
                { dialogueID = 9; }

                else if (DialogueManager.instance.chooseFlag == 2)
                { dialogueID = 10; }

                DialogueManager.instance.chooseFlag = 0;
                break;



                case "김나중" :
                    contextList = DataManager.instance.GetDialogue(11, 11);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;

                case "마부장":
                    contextList = DataManager.instance.GetDialogue(11, 11);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                DialogueManager.instance.chooseFlag = 0;
                break;



           
            default : break;
        }
        ui_dialogue.SetActive(false);
    }
}
