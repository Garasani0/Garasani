using System.Collections;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public Dialogue[] contextList;
    public GameObject redLight;

    int itemFlag = 0;
    public GameObject item;
    public GameObject nextSceneObject;
    Collider2D nextSceneCollider;

    AudioSource zipper; //효과음

    void Start()
    {
        zipper = GameObject.Find("zipper").GetComponent<AudioSource>(); //효과음
        nextSceneCollider = nextSceneObject.GetComponent<Collider2D>();
        nextSceneCollider.enabled = false;
    }

    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log("아이템: " + gameObject.name);
        Debug.Log(intertest.colitemname);

        //비상조명등을 가방에 넣음.
        if (itemFlag == 0 && intertest.colitemname == "item_비상조명등")
        {
            redLight.SetActive(false); //불빛을 끈다.
            zipper.Play(); //효과음 발생
            nextSceneCollider.enabled = true;//다음 씬으로 이동 가능
            StartCoroutine(AutoEvent()); //대사 출력 
        }


    }

    private IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(5, 5); //system: [비상조명등]을 가방에 넣었다.
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        contextList = DataManager.instance.GetDialogue(6, 6); //정민: 저희 이제 어디로 가야 하죠?
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        if (DialogueManager.instance.chooseFlag != 0)
        {
            item.SetActive(false);
            itemFlag = 1;
            DialogueManager.instance.ui_dialogue.SetActive(false);
            DialogueManager.instance.chooseFlag = 0;
            //Debug.Log("끝");
        }
    }
}
