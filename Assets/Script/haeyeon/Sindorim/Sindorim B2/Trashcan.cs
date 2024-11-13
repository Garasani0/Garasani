using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject player; // Player ������Ʈ
    public float interactionDistance = 2f; // Player���� ��ȣ�ۿ� �Ÿ�

    void Start()
    {
        // ó������ ��ǳ���� ��Ȱ��ȭ

        // �� ���� ��ȭ�� �ʿ��� CSV ������ �ҷ���
        DataManager.instance.csv_FileName = "SindorimB1B2";
        DataManager.instance.DialogueLoad();
        Debug.Log("SindorimB1B2 CSV ���� �ҷ����� �Ϸ�");
    }

    void OnMouseDown()
    {
        // Player�� ��������Ʈ ���� �Ÿ� ���
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // ���� �Ÿ� �ȿ� ���� ���� ��ȭ ����
        if (distance <= interactionDistance)
        {
            StartCoroutine(StartDialogueWithChoices(9)); // ID=9�� ������ �ִ� ��ȭ ����
        }
        else
        {
            Debug.Log("Player�� �ʹ� �ָ� �ֽ��ϴ�. ��ȣ�ۿ��� �� �����ϴ�.");
        }
    }

    private IEnumerator StartDialogueWithChoices(int dialogueID)
    {
        // ��ȭ UI Ȱ��ȭ
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // ������ ID�� ��ȭ ������ �ҷ��� (������ ����)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        DialogueManager.instance.processChoose(contextList); // ������ ��ȭ ����
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0); // ������ �� ������ ���

        // ���� ����� ���� ���� ��ȭ ID ����
        if (DialogueManager.instance.chooseFlag == 1)
        {
            yield return StartCoroutine(StartDialogue(10)); // ù ��° �������� �����ϸ� ID=10���� �̵�
        }
        else if (DialogueManager.instance.chooseFlag == 2)
        {
            yield return StartCoroutine(StartDialogue(11)); // �� ��° �������� �����ϸ� ID=11���� �̵�
        }

        // ������ �÷��� �ʱ�ȭ �� ��ȭ UI ��Ȱ��ȭ
        DialogueManager.instance.chooseFlag = 0;
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    private IEnumerator StartDialogue(int dialogueID)
    {
        // ������ ID�� ��ȭ ������ �ҷ��� (������ ����)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    }
}
