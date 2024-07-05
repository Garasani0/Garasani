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

public class tutorialscript : MonoBehaviour
{
    public GameObject ��ǳ��;
    public GameObject ��ư;


    private bool isMouseOver = false; //���� ������Ʈ ���� Ŀ���� �ִ����� ���� �÷���
    public GameObject InteractionView;
    public TMP_Text ����;
    public GameObject ����������;
    private RectTransform interactionViewRectTransform;
    public Vector3 mousePosition; //���콺 Ŀ�� ��ǥ
    public Vector3 worldPosition; //���콺 Ŀ�� ������ǥ


    public TMP_Text ����;
    public TMP_Text �̸�;
    int scriptcounter = 0;
    int objectcounter = 0;
    string[] text = new string[10] {"��...","�Ӹ��� �� ���� �ε��� �� ������...","...","�ٵ� �� �̸� ��������? ���� �ƹ��� ����?","...","������ �� ���ƴٳຼ��.","...?","...�̰� ���� �Ҹ���...?","���ʿ��� ���� �ٰ����� �־�...","...!" };
    string[] ������Ʈ = new string[4] { "�ٴڿ� �������ִ� ���� �ɰ���", "���ڿ� �������ִ� ������ ����", "���ڿ� �������ִ� Ű��", "�������� ��" };
    string[] ��ȣ�ۿ� = new string[4] { "[������ ����] : ������ �� �� ���� �۾��� ������ ����. �����ϰ� �������ִ�.", "[������ �ΰ� ���� ������ ����]�� ���濡 ì���.", "[������ �기 Ű��]�� ���濡 ì���.", "���𰡿� �ɸ� �� ���� ������ �ʴ´�" };
    // Start is called before the first frame update
    void Start()
    {
        ��ǳ��.SetActive(true);
        �̸�.text = customize.playername;
        ����.text = text[scriptcounter];
        scriptcounter++;
        //interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        //InteractionView.SetActive(false);
    }
    public void button()
    {
        if (scriptcounter<=5)
        {
            �̸�.text = customize.playername;
            ����.text = text[scriptcounter];
            scriptcounter++;
        }
        else if (scriptcounter==6)
        {
            ��ǳ��.SetActive(false);
        }
    }
    /*   private void OnMouseOver() //������ ���� Ŀ�� �ִ� �� ���� 
       {
           if (!isMouseOver) //Ŀ���� ������Ʈ ���� �ö��� �� ���� 1���� ����
           {
               isMouseOver = true;
               string objectName = gameObject.name; //Ŀ�� ������ ������Ʈ �̸� 
               Debug.Log("���콺 ����" + objectName);

               Vector3 mousePosition = Input.mousePosition; //Ŀ�� ��ǥ ������ 
               worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

               ActiveInteraction(); //����â on
           }

       }
       void OnMouseExit()
       {
           // ���콺�� ������Ʈ���� ����� �� �÷��׸� ����
           isMouseOver = false;
           InteractionView.SetActive(false);
       }



       public void ActiveInteraction()
       {
           InteractionView.transform.position = (worldPosition); //������Ʈ Ŀ�� ��ġ�� ����â �̵� 
           InteractionView.SetActive(true); //Ŀ�� ���� �� ����â on
           if(gameObject.name=="����������")
           {
               objectcounter = 0;
               ����.text = ��ȣ�ۿ�[objectcounter];
           }
       }
    */

    // Update is called once per frame
    int clickflag = 0;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "�ʹ� �ǰ��ؼ� �޸� �� ����.";

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ��ǳ��.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject clickobj = hit.transform.gameObject;
                if (clickflag == 0 && clickobj.name == "�������̹�")
                {
                    
                       
                            ��ǳ��.SetActive(true);
                            �̸�.text = "System";
                            ����.text = "���� ���ȴ�";
                            clickflag = 1;
                }
                else if (clickflag==1&& clickobj.name == "�������̹�")
                {
                   
                        ��ǳ��.SetActive(true);
                        �̸�.text = "System";
                        ����.text = "���� ĭ���� �̵��Ѵ�";
                        clickflag = 2;
                    
                }
                else if (clickobj.name=="����������")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ ����] : ������ �� �� ���� �۾��� ������ ����. �����ϰ� �������ִ�. ";
                    clickobj.SetActive(false);
                }
                else if (clickobj.name == "����������")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ �ΰ� ���� ������ ����]�� ���濡 ì���";
                    clickobj.SetActive(false);
                }
                else if (clickobj.name== "Ű��")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ �기 Ű��]�� ���濡 ì���.";
                    clickobj.SetActive(false);
                }



            }
        }
    }
}
