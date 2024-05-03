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


public class customize : MonoBehaviour
{
    //������ ���ӿ�����Ʈ�� ����
    public GameObject Player_front;

    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;
    public GameObject eye4;
    public GameObject eye5;

    public GameObject eye1_left;
    public GameObject eye2_left;
    public GameObject eye3_left;
    public GameObject eye4_left;
    public GameObject eye5_left;

    public GameObject eye1_right;
    public GameObject eye2_right;
    public GameObject eye3_right;
    public GameObject eye4_right;
    public GameObject eye5_right;

    public GameObject hair1;
    public GameObject hair2;
    public GameObject hair3;
    public GameObject hair4;
    public GameObject hair5;

    public GameObject hair1_left;
    public GameObject hair2_left;
    public GameObject hair3_left;
    public GameObject hair4_left;
    public GameObject hair5_left;

    public GameObject hair1_right;
    public GameObject hair2_right;
    public GameObject hair3_right;
    public GameObject hair4_right;
    public GameObject hair5_right;

    public GameObject hair1_back;
    public GameObject hair2_back;
    public GameObject hair3_back;
    public GameObject hair4_back;
    public GameObject hair5_back;

    public GameObject hood_front;
    public GameObject hood_left;
    public GameObject hood_right;
    public GameObject hood_back;

    public GameObject img1;
    public GameObject img2;



    public GameObject eyeleft;
    public GameObject eyeright;
    public GameObject hairright;
    public GameObject hairleft;
    public GameObject Player_left;
    public GameObject Player_right;
    public GameObject Player_back;
    public TMP_Text hairtxt;
    public TMP_Text eyetxt;

    int eyenum = 0; //����� ������� �����ϴ� �����Դϴ�
    int hairnum = 0; //����� ������� �����ϴ� �����Դϴ�
    int sceneflag = 0; //Ŀ���Ҿ��� ���ѷα׾��� �����ϴ� �÷����Դϴ�!

    string[] hair = new string[5] { "    ���01", "    ���02", "    ���03", "    ���04", "    ���05" }; 
    string[] eye = new string[5] { "    ��01", "    ��02", "    ��03", "    ��04", "    ��05" };
    

    // Start is called before the first frame update
    void Start() //Ŀ���Ҿ������� �÷��̾� ���� �⺻���� �������ݴϴ�
    {
        Player_front.SetActive(true); //�÷��̾��� �ո�� 
        Player_back.SetActive(false);
        Player_left.SetActive(false);
        Player_right.SetActive(false);
        hood_front.SetActive(true); // �ո�� �ĵ� 
        hood_left.SetActive(true);
        hood_right.SetActive(true);
        hood_back.SetActive(true);
        eye1.SetActive(true); //�⺻ �� 1
        hair1.SetActive(true); // �⺻ ��� 1

    }
    public void move() 
    {
        if (sceneflag != 0) //Ŀ���Ҿ������� �� �����̴� �÷��̾ ���ѷα׾������� ������ �� �ְ��մϴ� .
        {
            if (Input.GetKey(KeyCode.W))
            {
                playeroff();
                Player_back.SetActive(true);

                Player_back.transform.Translate(Vector2.up); //�����϶��� �� 4������ �̹����� ���� ������ �ٳ���մϴ�
                Player_front.transform.Translate(Vector2.up);
                Player_left.transform.Translate(Vector2.up);
                Player_right.transform.Translate(Vector2.up);
               
            }
            if (Input.GetKey(KeyCode.S))
            {
                playeroff();
                Player_front.SetActive(true);

                Player_back.transform.Translate(Vector2.down);
                Player_front.transform.Translate(Vector2.down);
                Player_left.transform.Translate(Vector2.down);
                Player_right.transform.Translate(Vector2.down);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playeroff();
                Player_left.SetActive(true);


                Player_back.transform.Translate(Vector2.left);
                Player_front.transform.Translate(Vector2.left);
                Player_left.transform.Translate(Vector2.left);
                Player_right.transform.Translate(Vector2.left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playeroff();
                Player_right.SetActive(true);


                Player_back.transform.Translate(Vector2.right);
                Player_front.transform.Translate(Vector2.right);
                Player_left.transform.Translate(Vector2.right);
                Player_right.transform.Translate(Vector2.right);
            }
        }


    }
    public void prologue() //���ѷα׾����� ��ȯ���ִ� ��ư�� ������ �Լ��Դϴ�. �÷��̾��� ������� ��ġ�� �������ְ� ���ѷα׾��� �ҷ��ɴϴ�
    {
        img1.SetActive(false);
        img2.SetActive(false);
       
        sizetransform(Player_front);
        
        
        sizetransform(Player_back);
        sizetransform(Player_left);
        sizetransform(Player_right);
        eyesize();
        hoodsize();
        hairsize();
        sceneflag = 1;
        SceneManager.LoadScene("prologue");
    }
   
    public void sizetransform(GameObject a) //���ӿ�����Ʈ�� �Ű������� �޾Ƽ� ũ��� ��ġ�� �������ݴϴ�.
    {
        GameObject p = a;
        
        if(sceneflag==0) 
        {
            RectTransform rectTran1 = p.GetComponent<RectTransform>();
            rectTran1.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75);
            RectTransform rectTran2 = p.GetComponent<RectTransform>();
            rectTran2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 75);
            a.transform.position = new Vector3(1000, 800, 0);
        }
      
       
    }
    public void eyesize() //������ �����Լ��� ��� �� �̹����� �����մϴ�
    {
        sizetransform(eye1);
        sizetransform(eye2);
        sizetransform(eye3);
        sizetransform(eye4);
        sizetransform(eye5);

        sizetransform(eye1_left);
        sizetransform(eye2_left);
        sizetransform(eye3_left);
        sizetransform(eye4_left);
        sizetransform(eye5_left);

        sizetransform(eye1_right);
        sizetransform(eye2_right);
        sizetransform(eye3_right);
        sizetransform(eye4_right);
        sizetransform(eye5_right);



    }
    public void hairsize() //������ �����Լ��� ��� ��� �̹����� �����մϴ�
    {
        sizetransform(hair1);
        sizetransform(hair2);
        sizetransform(hair3);
        sizetransform(hair4);
        sizetransform(hair5);

        sizetransform(hair1_left);
        sizetransform(hair2_left);
        sizetransform(hair3_left);
        sizetransform(hair4_left);
        sizetransform(hair5_left);

        sizetransform(hair1_right);
        sizetransform(hair2_right);
        sizetransform(hair3_right);
        sizetransform(hair4_right);
        sizetransform(hair5_right);

        sizetransform(hair1_back);
        sizetransform(hair2_back);
        sizetransform(hair3_back);
        sizetransform(hair4_back);
        sizetransform(hair5_back);

    }
    public void hoodsize() //������ �����Լ��� ��� �ĵ�Ƽ �̹����� �����մϴ�
    {
        sizetransform(hood_front);
        sizetransform(hood_back);
        sizetransform(hood_left);
        sizetransform(hood_right);
       
    }
        public void playeroff() // �÷��̾ �����¿�� �����϶� ��� �÷��̾��̹����� ��Ȱ��ȭ�ϰ�, �ش� ������ �̹����� �ҷ����� ����� ���� �Լ��Դϴ�.
    {
        Player_front.SetActive(false);
        Player_back.SetActive(false);
        Player_left.SetActive(false);
        Player_right.SetActive(false);
    }
 
    public void eyeleftOnclick() //Ŀ���ҿ� �ʿ��� �Լ����Դϴ�.
    {
        eyenum--;
        if (eyenum<0)
        {
            eyenum = 4;
        }
        eyetxt.text = eye[eyenum];

    }
    public void eyerightOnclick()
    {
        eyenum++;
        if (eyenum > 4)
        {
            eyenum = 0;
        }
        eyetxt.text = eye[eyenum];

    }
    public void hairleftOnclick()
    {
        hairnum--;
        if (hairnum < 0)
        {
            hairnum = 4;
        }
        hairtxt.text = hair[hairnum];

    }
    public void hairrightOnclick()
    {
        hairnum++;
        if (hairnum >4)
        {
            hairnum = 0;
        }
        hairtxt.text = hair[hairnum];

    }
    public void eyeoff() //������ ��� eye�� ����, Ŀ�������� ���κҷ����� ���� �Լ��Դϴ�.
    {
        eye1.SetActive(false);
        eye2.SetActive(false);
        eye3.SetActive(false);
        eye4.SetActive(false);
        eye5.SetActive(false);

        eye1_left.SetActive(false);
        eye2_left.SetActive(false);
        eye3_left.SetActive(false);
        eye4_left.SetActive(false);
        eye5_left.SetActive(false);

        eye1_right.SetActive(false);
        eye2_right.SetActive(false);
        eye3_right.SetActive(false);
        eye4_right.SetActive(false);
        eye5_right.SetActive(false);
    }
    public void hairoff() // ���� �����մϴ�
    {
        hair1.SetActive(false);
        hair2.SetActive(false);
        hair3.SetActive(false);
        hair4.SetActive(false);
        hair5.SetActive(false);

        hair1_left.SetActive(false);
        hair2_left.SetActive(false);
        hair3_left.SetActive(false);
        hair4_left.SetActive(false);
        hair5_left.SetActive(false);

        hair1_right.SetActive(false);
        hair2_right.SetActive(false);
        hair3_right.SetActive(false);
        hair4_right.SetActive(false);
        hair5_right.SetActive(false);

        hair1_back.SetActive(false);
        hair2_back.SetActive(false);
        hair3_back.SetActive(false);
        hair4_back.SetActive(false);
        hair5_back.SetActive(false);


    }
    public void puton() // Ŀ���ҵ� eye�� hair�� ������ �� �ְ� �ϴ� �Լ��Դϴ�.
    {
         switch(eyenum)
        {
            case 0:
                {
                    eyeoff();
                    eye1.SetActive(true);
                    eye1_right.SetActive(true);
                    eye1_left.SetActive(true);
                    break;
                }
            case 1:
                {
                    eyeoff();
                    eye2.SetActive(true);
                    eye2_right.SetActive(true);
                    eye2_left.SetActive(true);
                    break;
                }
            case 2:
                {
                    eyeoff();
                    eye3.SetActive(true);
                    eye3_right.SetActive(true);
                    eye3_left.SetActive(true);
                    break;
                }
            case 3:
                {
                    eyeoff();
                    eye4.SetActive(true);
                    eye4_right.SetActive(true);
                    eye4_left.SetActive(true);
                    break;
                }
            case 4:
                {
                    eyeoff();
                    eye5.SetActive(true);
                    eye5_right.SetActive(true);
                    eye5_left.SetActive(true);
                    break;
                }
            default:
                break;



        }
        switch (hairnum)
        {
            case 0:
                {
                    hairoff();
                    hair1.SetActive(true);
                    hair1_left.SetActive(true);
                    hair1_right.SetActive(true);
                    hair1_back.SetActive(true);

                    break;
                }
            case 1:
                {
                    hairoff();
                    hair2.SetActive(true);
                    hair2_left.SetActive(true);
                    hair2_right.SetActive(true);
                    hair2_back.SetActive(true);
                    break;
                }
            case 2:
                {
                    hairoff();
                    hair3.SetActive(true);
                    hair3_left.SetActive(true);
                    hair3_right.SetActive(true);
                    hair3_back.SetActive(true);
                    break;
                }
            case 3:
                {
                    hairoff();
                    hair4.SetActive(true);
                    hair4_left.SetActive(true);
                    hair4_right.SetActive(true);
                    hair4_back.SetActive(true);
                    break;
                }
            case 4:
                {
                    hairoff();
                    hair5.SetActive(true);
                    hair5_left.SetActive(true);
                    hair5_right.SetActive(true);
                    hair5_back.SetActive(true);
                    break;
                }
            default:
                break;



        }

    }
    // Update is called once per frame
    void Update()
    {
        puton();
        move(); 

        
    }
      
        
   
}
