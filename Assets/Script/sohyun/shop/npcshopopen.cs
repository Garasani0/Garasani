using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcshopopen : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public GameObject ShopUI;
    public static int sellflag = 0;
    public static bool jobcouflag = false;//�ڷ�ƾ �ߺ�����
    public static bool grandcouflag = false;//�ڷ�ƾ �ߺ�����
    public static bool angcouflag = false;//�ڷ�ƾ �ߺ�����
    bool coufirst = true;
    public static string nowinter;

    // Start is called before the first frame update
    void Start()
    {
      
        ShopUI.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        nowinter = gameObject.name;
       
        ShopUI.SetActive(true);

        if (SellManager.instance != null)
        {
            SellManager.instance.putinlist(Items);
        }
        else
        {
            Debug.LogError("SellManager �ν��Ͻ��� ã�� �� �����ϴ�.");
        }


    }
    void Update()
    {
      
        if (SellManager.instance != null && SellManager.instance.sellitem)
        {
            sellflag = 1;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && sellflag == 1)
        {
            if (coufirst == true)
            {
                coufirst = false;

                // NPCManager.instance�� null���� Ȯ��

                if (nowinter == "�����")
                {
                    jobcouflag = true;
                }
                else if (nowinter == "���� �Ĵ� �ҸӴ�")
                {
                    grandcouflag = true;
                }
                else if (nowinter == "�޹���")
                {
                    angcouflag = true;
                }

            }
        }

        // ESC Ű �Է� ó��
        if (Input.GetKeyDown(KeyCode.Escape) && sellflag != 1)
        {
            sellflag = 2;

            if (coufirst == true)
            {
                coufirst = false;

            }
            else if (nowinter == "�����")
            {
                jobcouflag = true;
            }
            else if (nowinter == "�޹���")
            {
                angcouflag = true;
            }


            }
        }


    }

