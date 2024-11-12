using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sindorim_1LineSub : MonoBehaviour
{

    public Dialogue[] contextList;
    public Transform playerFirst; //��ġ ���� 

    int dialogueID = 1;

    public string nextSceneName; //��ȭ �� �ٷ� ���� ������ �̵��� �� �ֵ���
    private bool hasTriggered = false; //�÷��̾�� ���� �浹 ����


    public IEnumerator AutoEvent()
    {
        Debug.Log(inSubway_0.instance.dialogueID);  // ���� ��ȭ ID�� �α׷� ���

        DialogueManager.instance.ui_dialogue.SetActive(true);  // ��ȭ UI Ȱ��ȭ

        contextList = DataManager.instance.GetDialogue(1, 4);
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);

        if (DialogueManager.instance.chooseFlag == 1)
            dialogueID = 2;

        else if (DialogueManager.instance.chooseFlag == 2)
            //dialogueID = 4;
            DialogueManager.instance.ui_dialogue.SetActive(false);

        DialogueManager.instance.chooseFlag = 0;

        DialogueManager.instance.ui_dialogue.SetActive(false);
        
        //��ȭ ���� �� 2�� ��
        yield return new WaitForSeconds(2f);
        // �� ��ȯ
        SceneManager.LoadScene(nextSceneName);
    }

    /*void Start()
    {
        DataManager.instance.csv_FileName = "<Sindorim_1LineSub>";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }*/

    private void OnTriggerEnter2D(Collider2D other) //�ƿ� �� ������ ������ �浹���� �� �ߵ��ǵ��� �ϱ� ���ؼ�
    {
        // Player �±׸� ���� ������Ʈ�� �浹�ϰ�, ���� Ʈ���ŵ��� ���� ���
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // �ߺ� ���� ����
            StartCoroutine(AutoEvent()); // ��ȭ �̺�Ʈ ����
        }
    }
}
