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

    AudioSource zipper; //ȿ����

    void Start()
    {
        zipper = GameObject.Find("zipper").GetComponent<AudioSource>(); //ȿ����
        nextSceneCollider = nextSceneObject.GetComponent<Collider2D>();
        nextSceneCollider.enabled = false;
    }

    void OnMouseDown()
    {
        Debug.Log("���콺Ŭ������");
        Debug.Log("������: " + gameObject.name);
        Debug.Log(intertest.colitemname);

        //���������� ���濡 ����.
        if (itemFlag == 0 && intertest.colitemname == "item_��������")
        {
            redLight.SetActive(false); //�Һ��� ����.
            zipper.Play(); //ȿ���� �߻�
            nextSceneCollider.enabled = true;//���� ������ �̵� ����
            StartCoroutine(AutoEvent()); //��� ��� 
        }


    }

    private IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(5, 5); //system: [��������]�� ���濡 �־���.
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        contextList = DataManager.instance.GetDialogue(6, 6); //����: ���� ���� ���� ���� ����?
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        if (DialogueManager.instance.chooseFlag != 0)
        {
            item.SetActive(false);
            itemFlag = 1;
            DialogueManager.instance.ui_dialogue.SetActive(false);
            DialogueManager.instance.chooseFlag = 0;
            //Debug.Log("��");
        }
    }
}
