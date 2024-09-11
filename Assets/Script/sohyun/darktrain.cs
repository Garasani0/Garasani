using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class darktrain : MonoBehaviour
{
    public static darktrain instance;
    public GameObject ui_dialogue; //��ǳ��
    private IEnumerator darkandlight;
    public GameObject button;
    public GameObject dark;
    public TMP_Text context;
    public TMP_Text name;
    public GameObject door;
    public static int doorflag = 0;

    [SerializeField] private GameObject targetAnimatorObject;
    public float moveSpeed = 5f;
    public string boolParameterName = "Left";
    private Animator NPCAnimator;
    public bool jmeventFlag = false; //���� �̺�Ʈ ���� �÷���

    public Dialogue[] contextList;
    public int dialogueID;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueID = 1;
       


        ui_dialogue.SetActive(false);

       
        DataManager.instance.csv_FileName = "1ȣ������";
        DataManager.instance.DialogueLoad(); // CSV ���� �ε�
        StartCoroutine(darkStart());

    }


    private IEnumerator darkroutine() //���� �����Ÿ� ȿ�� 
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }

    void dontmove()
    {
        customize.moveflag = 0;
        ui_dialogue.SetActive(true);

    }

    public IEnumerator darkStart()
    {
        ui_dialogue.SetActive(true);
        while (dialogueID < 6)
        {
            switch (dialogueID)
            {
                case 1:
                    contextList = DataManager.instance.GetDialogue(1, 5);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 2;
                    break;
                case 2:
                    contextList = DataManager.instance.GetDialogue(2, 3);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag==1)
                    {
                        dialogueID = 3;
                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 4;
                    }
                    DialogueManager.instance.chooseFlag = 0;

                    break;
                case 3:
                    contextList = DataManager.instance.GetDialogue(7,7 );
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                   
                    dialogueID = 5;


                    break;
                case 4:
                    contextList = DataManager.instance.GetDialogue(8, 8);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueID = 5;
                    break;

                case 5:
                    contextList = DataManager.instance.GetDialogue(9, 10);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueID = 6;
                    break;
                default:
                    dialogueID = 6;

                    break;
            }

        }
        ui_dialogue.SetActive(false);
        //StartCoroutine(cameramove.instance.JMmove());
      


    }



    // Update is called once per frame
   
   
}
