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

public class jungminemo : MonoBehaviour
{
    private Image imageComponent;
    public Sprite[] sprite;
    public TMP_Text who;





    public GameObject talksqu;
    






    void Start()
    {
        imageComponent=GetComponent<Image>();
        imageComponent.enabled = false;
        //if()
        //talksqu=GameObject.Find("��ǳ��");
       
       
       

    }
  
    
  

    // Update is called once per frame
    void Update()
    {
        // ���� ������Ʈ�� �θ� ������Ʈ�� �����ɴϴ�.
        if (talksqu != null && who.text != null)  // null üũ �߰�
        {
            
            if (talksqu.activeSelf && who.text.TrimEnd()== "����")
            {
                imageComponent.enabled = true;
                if (DialogueManager.jungminemoflag != null)
                {
                    imageComponent.sprite = sprite[DialogueManager.jungminemoflag];
                }
            }
            else
            {
                imageComponent.enabled = false;
            }
        }
        if(who.text!="����")
        {
            imageComponent.enabled = false;
        }
/*
        if (talksqu.activeSelf && who.text.Trim() == "����")
        {
            imageComponent.enabled = true;
            if (DialogueManager.jungminemoflag != null)
            {
                imageComponent.sprite = sprite[DialogueManager.jungminemoflag];
            }
          
        }
        else
        {
            imageComponent.enabled = false;
        }

        */




    }
}
