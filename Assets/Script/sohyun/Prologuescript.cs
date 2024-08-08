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
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject spot;//����ǥ
    public GameObject Button1;
    public GameObject realdark;
    public GameObject dark;
    public TMP_Text nameplayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(customize.playername);
        Debug.Log(customize.playerbirth);
        spot.SetActive(false);
        talksqu.SetActive(false);
        dark.SetActive(false);
        Invoke("proscript1", 2f);
       
    }
    void proscript1()
    {
        talksqu.SetActive(true);
        content.text = text[textflag++];
        nameplayer.text = customize.playername;
        Player.sitdown = 1;

    }
    public void buttondown1() // content�� �̾ ���� ��
    {
        if (textflag > 4)
        {
            talksqu.SetActive(false);
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
            talksqu.SetActive(true);

            content.text = text[textflag];
            nameplayer.text = customize.playername;
            textflag++;
            if (textflag == 2) // lookaround �Ÿ��� ����� �� �κ� 
            {
                talksqu.SetActive(false);
                Debug.Log("�÷��̾� �ɾƼ� �θ��� �Ÿ��� ���");
                Player.sitdown = 0;
                Player.lookaround = 1;
                //�÷��̾� �ɾƼ� lookaround �Ÿ��� ���
                talksqu.SetActive(true);
               



            }
            if (textflag == 3) // ��鸮�� ����� �� �κ�
            {
                Player.lookaround = 0;
                Player.sitdown = 1;
                talksqu.SetActive(false);
                CameraShake.shake();
                Debug.Log("��鸮�� ��� ");
                //customize.eyeo();
                Player.sitdown = 0;
                Player.shock = 1;
                spot.SetActive(true);
                Invoke("spot��Ȱ��ȭ", 1f);
                Invoke("talksquȰ��ȭ", 2f);
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
        realdark.SetActive(false);
        
    }
    void lightoff()
    {
        realdark.SetActive(true);

    }
    void lightcont()
    {
        Invoke("lighton", 0.2f);
        Invoke("lightoff", 0.3f);
    }
    void tutorialload()
    {
        Player.shock = 0;
        Player.sitdown = 0;
        Player.lookaround = 0;
        SceneManager.LoadScene("Pro_map1 beta");
        //SceneManager.LoadScene("sohyuntest");
    }
    
    void talksquȰ��ȭ()
    {
        talksqu.SetActive(true);
    }
    void spot��Ȱ��ȭ()
    {
        spot.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
