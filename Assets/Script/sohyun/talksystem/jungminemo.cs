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
        
                if (talksqu.activeSelf&&who.text =="����")
                {
                    imageComponent.enabled = true;
                    imageComponent.sprite = sprite[1];
                   
                }
                else
                {
                    imageComponent.enabled = false;
                }

                
       
               
            
        
    }
}
