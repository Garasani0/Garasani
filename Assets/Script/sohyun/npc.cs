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
    public TMP_Text content;
    public GameObject talksqu;
    public TMP_Text who;
    public static string interobj;
    int buttonnum = 0;

    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "���� ���� ����.", "���� ���� ���ٴϱ�?","....","�׳༮���� ���� �ΰ� ����.","�׳༮���� ���� �ΰ� ����.", "�ڽ� ������ Ű������ �� �ҿ���ٴ���...","....","�� �ٱ���....���� ���״���?" };
    string[] helpcontent = new string[5] { "�̻��ϴ�...�Ȱ��� ���� ��� �־��µ�.....", "��...�л�. Ȥ�� �� �Ȱ� �� �þ��?", "�̻��ϳ�...", "�츮 ���ֶ� �� ��ҳ�....", "�츮 ���� ���Ƽ� �ִ� �ž�..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "����,�ű�!", "���� ��� �ΰ� �ٴϴ� �ž�?", "��." };
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 0;
        }
    }
    
    public void buttondown()
    {
        buttonnum++;
        Debug.Log(interobj);
        Debug.Log(buttonnum);
        if (interobj == "��Ҹ� �ϴ� ����")
        {
            if (buttonnum > 7)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "��Ҹ� �ϴ� ����";
                content.text = weildcontent[buttonnum];

            }
        }
        else if(interobj == "������ �ʿ��غ��̴� ����")
        {
            if (buttonnum > 2)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "������ �ʿ��غ��̴� ����";
                content.text = helpcontent[buttonnum];

            }
        }

        else if (interobj == "������ ��ġ�� ����")
        {
            if (buttonnum > 0)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "������ ��ġ�� ����";
                content.text = objcontent[buttonnum];

            }
        }

        else if (interobj == "�ú�Ŵ³���")
        {
            if (buttonnum > 2)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "�ú� �Ŵ� ����";
                content.text = angercontent[buttonnum];

            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("���콺Ŭ������");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (playercolflag==1&&gameObject.name == "��Ҹ� �ϴ� ����")
        {
            interobj = "��Ҹ� �ϴ� ����";
           
            if(buttonnum==0)
            {
                talksqu.SetActive(true);
                who.text = "��Ҹ� �ϴ� ����";
                content.text = weildcontent[0];
            }
           
            Debug.Log("��Ҹ� �ϴ� ���� Ŭ����");
           
        }

        if (playercolflag == 1 && gameObject.name == "������ �ʿ��غ��̴� ����")
        {
            interobj = "������ �ʿ��غ��̴� ����";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "������ �ʿ��غ��̴� ����";
                content.text = helpcontent[0];
            }

         

        }

        if (playercolflag == 1 && gameObject.name == "������ ��ġ�� ����")
        {
            interobj = "������ ��ġ�� ����";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "������ ��ġ�� ����";
                content.text = objcontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "�ú�Ŵ³���")
        {
            interobj = "�ú�Ŵ³���";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "�ú� �Ŵ� ����";
                content.text = angercontent[0];
            }



        }


    }
// Start is called before the first frame update
void Start()
    {
        talksqu.SetActive(false);
        customize.sceneflag = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playercolflag);
    }
}
