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

public class tutorial2 : MonoBehaviour
{
    public GameObject ��ǳ��;
    public GameObject ��ư;
    public TMP_Text ����;
    public TMP_Text �̸�;
    int textflag = 0;
    public GameObject door;
    string[] text = new string[4] {  "...?", "...�̰� ���� �Ҹ���...?", "���ʿ��� ���� �ٰ����� �־�...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newposition = door.transform.position;
        customize.playertrans(newposition.x, newposition.y);
        ��ǳ��.SetActive(false);
        �̸�.text = customize.playername;
        ����.text = text[textflag];
        Invoke("dontmove", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Ŭ���ν�");
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "�������̹�")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";

                }
            }
        }
    }
    public void button()
    {
        if (textflag==0)
        {
            textflag++;
        }
        if (textflag <= 2)
        {
            �̸�.text = customize.playername;
            ����.text = text[textflag];
            textflag++;
        }
        else if (textflag == 3)
        {
            Debug.Log("������");
            ��ǳ��.SetActive(false);
            customize.moveflag = 1;
        }
    }
    void dontmove()
    {
        customize.moveflag = 0;
        ��ǳ��.SetActive(true);

    }
}
