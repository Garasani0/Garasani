using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;

public class npc : MonoBehaviour
{
    public TMP_Text ����;
    public GameObject ��ǳ��;
    public TMP_Text �̸�;
    public static string ��ȣ�ۿ밴ü;
    int buttonnum = 0;

    public int �÷��̾��浹�÷��� = 0;
    string[] ��Ҹ���� = new string[8] { "���� ���� ����.", "���� ���� ���ٴϱ�?","....","�׳༮���� ���� �ΰ� ����.","�׳༮���� ���� �ΰ� ����.", "�ڽ� ������ Ű������ �� �ҿ���ٴ���...","....","�� �ٱ���....���� ���״���?" };
    string[] ������ = new string[5] { "�̻��ϴ�...�Ȱ��� ���� ��� �־��µ�.....", "��...�л�. Ȥ�� �� �Ȱ� �� �þ��?", "�̻��ϳ�...", "�츮 ���ֶ� �� ��ҳ�....", "�츮 ���� ���Ƽ� �ִ� �ž�..." };
    string[] ���Ǵ�� = new string[1] { "................." };
    string[] �ú��� = new string[3] { "����,�ű�!", "���� ��� �ΰ� �ٴϴ� �ž�?", "��." };
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            �÷��̾��浹�÷��� = 1;
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            �÷��̾��浹�÷��� = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            �÷��̾��浹�÷��� = 0;
        }
    }
    
    public void buttondown()
    {
        buttonnum++;
        Debug.Log(��ȣ�ۿ밴ü);
        Debug.Log(buttonnum);
        if (��ȣ�ۿ밴ü == "��Ҹ� �ϴ� ����")
        {
            if (buttonnum > 7)
            {
                ��ǳ��.SetActive(false);
                buttonnum = 0;
                ��ȣ�ۿ밴ü = null;
            }
            else
            {
                �̸�.text = "��Ҹ� �ϴ� ����";
                ����.text = ��Ҹ����[buttonnum];

            }
        }
        else if(��ȣ�ۿ밴ü == "������ �ʿ��غ��̴� ����")
        {
            if (buttonnum > 2)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                ��ǳ��.SetActive(false);
                buttonnum = 0;
                ��ȣ�ۿ밴ü = null;
            }
            else
            {
                �̸�.text = "������ �ʿ��غ��̴� ����";
                ����.text = ������[buttonnum];

            }
        }

        else if (��ȣ�ۿ밴ü == "������ ��ġ�� ����")
        {
            if (buttonnum > 0)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                ��ǳ��.SetActive(false);
                buttonnum = 0;
                ��ȣ�ۿ밴ü = null;
            }
            else
            {
                �̸�.text = "������ ��ġ�� ����";
                ����.text = ���Ǵ��[buttonnum];

            }
        }

        else if (��ȣ�ۿ밴ü == "�ú�Ŵ³���")
        {
            if (buttonnum > 2)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                ��ǳ��.SetActive(false);
                buttonnum = 0;
                ��ȣ�ۿ밴ü = null;
            }
            else
            {
                �̸�.text = "�ú� �Ŵ� ����";
                ����.text = �ú���[buttonnum];

            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("���콺Ŭ������");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.�浹�����۸�);

        if (�÷��̾��浹�÷���==1&&gameObject.name == "��Ҹ� �ϴ� ����")
        {
            ��ȣ�ۿ밴ü = "��Ҹ� �ϴ� ����";
           
            if(buttonnum==0)
            {
                ��ǳ��.SetActive(true);
                �̸�.text = "��Ҹ� �ϴ� ����";
                ����.text = ��Ҹ����[0];
            }
           
            Debug.Log("��Ҹ� �ϴ� ���� Ŭ����");
           
        }

        if (�÷��̾��浹�÷��� == 1 && gameObject.name == "������ �ʿ��غ��̴� ����")
        {
            ��ȣ�ۿ밴ü = "������ �ʿ��غ��̴� ����";

            if (buttonnum == 0)
            {
                ��ǳ��.SetActive(true);
                �̸�.text = "������ �ʿ��غ��̴� ����";
                ����.text = ������[0];
            }

         

        }

        if (�÷��̾��浹�÷��� == 1 && gameObject.name == "������ ��ġ�� ����")
        {
            ��ȣ�ۿ밴ü = "������ ��ġ�� ����";

            if (buttonnum == 0)
            {
                ��ǳ��.SetActive(true);
                �̸�.text = "������ ��ġ�� ����";
                ����.text = ���Ǵ��[0];
            }



        }

        if (�÷��̾��浹�÷��� == 1 && gameObject.name == "�ú�Ŵ³���")
        {
            ��ȣ�ۿ밴ü = "�ú�Ŵ³���";

            if (buttonnum == 0)
            {
                ��ǳ��.SetActive(true);
                �̸�.text = "�ú� �Ŵ� ����";
                ����.text = �ú���[0];
            }



        }


    }
// Start is called before the first frame update
void Start()
    {
        ��ǳ��.SetActive(false);
        customize.sceneflag = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(�÷��̾��浹�÷���);
    }
}
