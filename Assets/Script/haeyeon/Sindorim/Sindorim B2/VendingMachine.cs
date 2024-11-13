using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject player; // Player ������Ʈ
    public float interactionDistance = 2f; // Player���� ��ȣ�ۿ� �Ÿ�
    private int clickCount = 0; // ���Ǳ⸦ ���� Ƚ��

    void Start()
    {
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
            clickCount++; // ���Ǳ� Ŭ�� Ƚ�� ����

            // Ŭ�� Ƚ���� ���� ��ȭ ID ����
            if (clickCount == 3)
            {
                StartCoroutine(StartDialogue(8)); // �� ��° Ŭ�� �� ID=8 ��ȭ ����
                clickCount = 0; // Ŭ�� Ƚ�� �ʱ�ȭ
            }
            else
            {
                StartCoroutine(StartDialogue(7)); // �� ��°�� �ƴ� ��� ID=7 ��ȭ ����
            }
        }
        else
        {
            Debug.Log("Player�� �ʹ� �ָ� �ֽ��ϴ�. ��ȣ�ۿ��� �� �����ϴ�.");
        }
    }

    private IEnumerator StartDialogue(int dialogueID)
    {
        // ��ȭ UI Ȱ��ȭ
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // ������ ID�� ��ȭ ������ �ҷ��� (�������� ����)
        Dialogue[] contextList = DataManager.instance.GetDialogue(dialogueID, dialogueID);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        // ��ȭ�� ������ UI ��Ȱ��ȭ
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
