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

public class Prologuescript : MonoBehaviour
{
    string[] text = new string[5] { " ��, ȯ���ϱ� ������. ���� ���� ���� �� �� �ٿ�����.", " ���� �ȳ� ���", " ��, ����ö �� ���� ������...", "��! �̰� �� �̷�??!!", "��!!!!!!!!!!!!!!" };
    int textflag = 0;
    public TMP_Text ���;
    public GameObject ��ǳ��;
    public GameObject ����ǥ;
    public GameObject Button1;
    public GameObject ����;
    public GameObject dark;
    public TMP_Text �̸�;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(customize.playername);
        Debug.Log(customize.playerbirth);
        ����ǥ.SetActive(false);
        ��ǳ��.SetActive(false);
        dark.SetActive(false);
        Invoke("proscript1", 2f);
       
    }
    void proscript1()
    {
        ��ǳ��.SetActive(true);
        ���.text = text[textflag++];
        �̸�.text = customize.playername;

    }
    public void buttondown1() // ��簡 �̾ ���� ��
    {
        if (textflag > 4)
        {
            ��ǳ��.SetActive(false);
            CameraShake.stopsk();
            CancelInvoke("lighton");
            CancelInvoke("lightoff");
            dark.SetActive(true);
            customize.sceneflag = 2;
            Invoke("tutorialload", 1f);

            //���� �� �̹��� Ȱ��ȭ 
        }
        else
        {
            ��ǳ��.SetActive(true);

            ���.text = text[textflag];
            �̸�.text = customize.playername;
            textflag++;
            if (textflag == 2) // �θ��� �Ÿ��� ����� �� �κ� 
            {
                ��ǳ��.SetActive(false);
                Debug.Log("�÷��̾� �ɾƼ� �θ��� �Ÿ��� ���");
                customize.eyec();
                //�÷��̾� �ɾƼ� �θ��� �Ÿ��� ���
                ��ǳ��.SetActive(true);



            }
            if (textflag == 3) // ��鸮�� ����� �� �κ�
            {
                ��ǳ��.SetActive(false);
                CameraShake.shake();
                Debug.Log("��鸮�� ��� ");
                customize.eyeo();
                ����ǥ.SetActive(true);
                Invoke("����ǥ��Ȱ��ȭ", 1f);
                Invoke("��ǳ��Ȱ��ȭ", 2f);
            }
            if (textflag == 4 )
            {
                CameraShake.shakeharder();
                InvokeRepeating("lighton", 0f, 0.001f);
                InvokeRepeating("lightoff", 0f, 0.008f);



            }
        }
       
        
        
      
        
    }
    void lighton()
    {
        ����.SetActive(false);
        
    }
    void lightoff()
    {
        ����.SetActive(true);

    }
    void lightcont()
    {
        Invoke("lighton", 0.2f);
        Invoke("lightoff", 0.3f);
    }
    void tutorialload()
    {
        SceneManager.LoadScene("Pro_Map");
    }
    
    void ��ǳ��Ȱ��ȭ()
    {
        ��ǳ��.SetActive(true);
    }
    void ����ǥ��Ȱ��ȭ()
    {
        ����ǥ.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
