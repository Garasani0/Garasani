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
    private IEnumerator �����Ÿ�;
    public GameObject ��ư;
    public GameObject dark;
    public TMP_Text ����;
    public TMP_Text �̸�;
    public static int textflag = 0;
    public GameObject door;
    public static int doorflag = 0;
    
    string[] text = new string[4] {  "...?", "...�̰� ���� �Ҹ���...?", "���ʿ��� ���� �ٰ����� �־�...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newposition = door.transform.position;
        Player.playertrans(newposition.x+3, newposition.y);
        ��ǳ��.SetActive(false);
        �̸�.text = customize.playername;
        ����.text = text[textflag];
        Invoke("dontmove", 1f);
        �����Ÿ� = ����();
    }
    private IEnumerator ����()
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(�����Ÿ�);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "�������̹�")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
                    textflag++;

                    //SceneManager.LoadScene("Dialogue");
                }
            }
        }
    }
    
    public void doordown()
    {
        Debug.Log("Ŭ����");
        if (doorflag==0)
        {
            
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
            textflag++;
            doorflag++;
        }
    }
   
    public void button()
    {
        if (textflag == 0)
        {
            textflag++;
        }
        else if (textflag <= 1)
        {
            �̸�.text = customize.playername;
            ����.text = text[textflag];
            textflag++;

        }
        else if (textflag == 2)
        {
            �̸�.text = customize.playername;
            ����.text = text[textflag];
            //customize.moveflag = 1;
            //��ǳ��.SetActive(false);
            textflag++;
        }
        else if (textflag == 3 && doorflag ==0)
        {
            ��ǳ��.SetActive(false);
        }
        else if (textflag==4 && doorflag==1)
        {

            Debug.Log("������");
            
            ��ǳ��.SetActive(true);
            �̸�.text = customize.playername;
            ����.text = text[3];
            textflag++;
        }

        else if (textflag > 4)
        {
            ��ǳ��.SetActive(false);
            SceneManager.LoadScene("Prologue2");

        }

    }
    void dontmove()
    {
        customize.moveflag = 0;
        ��ǳ��.SetActive(true);

    }
}
