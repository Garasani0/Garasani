using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class SaveInteract : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public GameObject options;

    private int gointer = 0;
    private string interobj;
    private Vector2 pos;

    public GameObject SaveUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            if (gameObject.name == "������" && gointer == 0)
            {
                pos = transform.position;
                interobj = "������";
                Player.moveflag = 0;
                talksqu.SetActive(true);
                options.SetActive(true);
                button.SetActive(false);
                who.text = customize.playername;
                content.text = "�̵��ұ�?";
                option1.text = "> �±׸� ��´�.";
                option2.text = "> �±׸� ���� �ʴ´�.";

                Debug.Log("�ؽ�Ʈ�� �����Ǿ����ϴ�: " + content.text);
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
        // ��ȭ �Ŵ����� chooseFlag ���� Ȯ��
        int choice = DialogueManager.instance.chooseFlag;
        Debug.Log("���õ� �÷���: " + choice);

        if (interobj == "������")
        {
            if (choice == 1)
            {
                SaveUI.SetActive(true);
                // �±׸� ��´�
                Player.moveflag = 1;
                button.SetActive(true);
                gointer = 1;
                Player.playertrans(transform.position.x - 3, transform.position.y);
                Debug.Log("�÷��� 1: �±׸� �����.");
            }
            else if (choice == 2)
            {
                Player.playertrans(pos.x + 1, pos.y); // �÷��̾� �̵� Ȯ�ο� �����
                Debug.Log("�÷��̾� �̵�: " + pos.x + 1 + ", " + pos.y);
                Player.moveflag = 1;
                button.SetActive(true);
                Debug.Log("�÷��� 2: �±׸� ���� �ʾҴ�.");
            }
            else
            {
                Debug.LogWarning("��ȿ���� ���� ������");
            }
        }

        // �ɼ� UI�� ��Ȱ��ȭ�ϰ� ������ �Ϸ�Ǿ����� ǥ��
        options.SetActive(false);
        talksqu.SetActive(false);

        if (DialogueManager.instance != null)
        {
            if (DialogueManager.instance.currentIdx < DialogueManager.instance.contextList.Length - 1)
            {
                DialogueManager.instance.onClickNextButton();  // ���� �� ��ȭ ����
            }
            else
            {
                Debug.Log("��ȭ�� �������ϴ�.");
                Player.moveflag = 1;  // ��ȭ�� �������� �÷��̾� ������ Ȱ��ȭ
            }
        }
        else
        {
            Debug.LogError("DialogueManager �ν��Ͻ��� �������� �ʽ��ϴ�.");
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
        if (interobj == "������")
        {
            talksqu.SetActive(false);
            interobj = null;
            ClearOptions();
            content.text = "";
        }
    }

    void Start()
    {
        talksqu.SetActive(false);
        options.SetActive(false);
        button.SetActive(true);
        SaveUI.SetActive(false);

        customize.sceneflag = 2;
        customize.moveflag = 1;
    }

    void Update()
    {
        // ������ ó��
        if (DialogueManager.instance.chooseFlag > 0)
        {
            ProcessChoice();  // �������� ���� ó��
            DialogueManager.instance.chooseFlag = 0;  // ó�� �� �÷��� �ʱ�ȭ
        }
    }
}