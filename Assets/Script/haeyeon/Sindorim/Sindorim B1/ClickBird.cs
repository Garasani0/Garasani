using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBird : MonoBehaviour
{
    public GameObject player;  // Player ������Ʈ
    public float interactionDistance = 2f;  // Player���� ��ȣ�ۿ� �Ÿ�
    public Dialogue[] contextList;
    int dialogueID = 6; //dialogue ���� ���̵�

    void Start()
    {
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(StartDialogue());
    }

    void OnMouseDown()
    {
        // Player�� ��������Ʈ ���� �Ÿ� ���
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // ���� �Ÿ� �ȿ� ���� ���� ��ȭ ����
        if (distance <= interactionDistance)
        {
            StartCoroutine(StartDialogue());
        }
        else
        {
            Debug.Log("Player�� �ʹ� �ָ� �ֽ��ϴ�. ��ȣ�ۿ��� �� �����ϴ�.");
        }
    }

    private IEnumerator StartDialogue()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(6, 6);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
