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
public class door2 : MonoBehaviour
{
    public GameObject ��ǳ��;
    public TMP_Text ����;
    public TMP_Text �̸�;

    void OnMouseDown()
    {
        Debug.Log("Ŭ����");
        if (tutorial2.doorflag == 0)
        {

            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
            tutorial2.textflag++;
            tutorial2.doorflag++;
        }
    }
    
}
