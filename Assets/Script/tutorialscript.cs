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
    public TMP_Text ����;
    public TMP_Text �̸�;
    int scriptcounter = 0;
    string[] text = new string[10] {"��...","�Ӹ��� �� ���� �ε��� �� ������...","...","�ٵ� �� �̸� ��������? ���� �ƹ��� ����?","...","������ �� ���ƴٳຼ��.","...?","...�̰� ���� �Ҹ���...?","���ʿ��� ���� �ٰ����� �־�...","...!" };
    string[] ��ȣ�ۿ� = new string[4] { "[������ ����] : ������ �� �� ���� �۾��� ������ ����. �����ϰ� �������ִ�.", "[������ �ΰ� ���� ������ ����]�� ���濡 ì���.", "[������ �기 Ű��]�� ���濡 ì���.", "���𰡿� �ɸ� �� ���� ������ �ʴ´�" };
    // Start is called before the first frame update
    void Start()
    {
        ��ǳ��.SetActive(true);
        �̸�.text = customize.playername;
        ����.text = text[scriptcounter];
        scriptcounter++;
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
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
