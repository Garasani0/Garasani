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

public class 튜토리얼아이템 : MonoBehaviour
{
    int clickflag = 0;
    
    int keyringflag = 0;
    int airpotflag = 0;
    int paperflag= 0;
   
    public TMP_Text context;
    public TMP_Text who;
    public GameObject talksqu;
    public GameObject keyring;
    public GameObject oddairpot;
    public GameObject paper;
    // public GameObject keyringcontent;
    // public GameObject airpotcontent;
    // public GameObject papercontent;

    AudioSource zipper;

    //public Inventory inventory; // Inventory 스크립트 참조

    // Start is called before the first frame update
    void Start()
    {
        zipper = GameObject.Find("zipper").GetComponent<AudioSource>();
    }

    void nothing(){ //아무것도 안함 

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (clickflag == 0 && intertest.colitemname == "열차사이문")
        {


            talksqu.SetActive(true);
            who.text = "System";
            context.text = "문이 열렸다";
            clickflag = 1;

        }
        else if (clickflag >= 1 && intertest.colitemname == "열차사이문")
        {

            talksqu.SetActive(true);
            who.text = "System";
            if (tutorialscript.gotoflag < 3)
            {
                context.text = "열차를 조금 더 둘러보자. ";
            }
            else
            {
                context.text = "다음 칸으로 이동한다";
                SceneManager.LoadScene("Pro_map2_2"); 
            }

            clickflag = 2;


        }
        else if (paperflag== 0&& intertest.colitemname == "찢겨진 부적")
        {
            talksqu.SetActive(true);
            who.text = "System";
            context.text = "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다. ";
            paper.SetActive(false);
            //papercontent.SetActive(false);
            tutorialscript.gotoflag++;
            //inventory.AddItem("찢겨진부적");
            
            paperflag= 1;
        }
        else if (airpotflag==0&&intertest.colitemname == "에어팟한쪽")
        {
            talksqu.SetActive(true);
            who.text = "System";
            zipper.Play();
            context.text = "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다";
            oddairpot.SetActive(false);
            //airpotcontent.SetActive(false);
            tutorialscript.gotoflag++;
            //inventory.AddItem(intertest.colitemname);
            airpotflag = 1;
        }
        else if (keyringflag==0&&intertest.colitemname == "키링")
        {
            talksqu.SetActive(true);
            who.text = "System";
            zipper.Play();
            context.text = "[누군가 흘린 키링]을 가방에 챙겼다.";
            keyring.SetActive(false);
            //keyringcontent.SetActive(false);
            tutorialscript.gotoflag++;
            //inventory.AddItem("키링");
            keyringflag = 1;
           
        }
        

    }
   
}
