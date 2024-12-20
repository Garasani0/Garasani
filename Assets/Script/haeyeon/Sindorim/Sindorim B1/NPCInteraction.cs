using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private bool hasTriggered = false; // �� �� ���� ���� Ȯ��
    public GameObject player; // �÷��̾� ������Ʈ
    public Dialogue[] contextList;
    int dialogueID = 5; //dialogue ���� ���̵�

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾�� �浹 ��
        if (!hasTriggered && collision.gameObject == player)
        {
            hasTriggered = true; // �浹 ó�� �÷��� ����
            StartCoroutine(AutoEvent()); // Dialogue ����
        }
    }

    private void Start()
    {
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load �Ϸ�");

        // Start���� AutoEvent ȣ�� ����
    }

    public IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}