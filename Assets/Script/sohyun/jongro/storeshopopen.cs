using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class storeshopopen : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public GameObject ShopUI;
   

    // Start is called before the first frame update
    void Start()
    {
        
        ShopUI.SetActive(false);
    }
    void Update()
    {
        Debug.Log("ShopUI activeSelf: " + ShopUI.activeSelf);
        Debug.Log("ShopUI activeInHierarchy: " + ShopUI.activeInHierarchy);
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        
        switch (gameObject.name)
        {
            case ("�������� ����"):
                {
                    if(jongronpcM.manjufirst==1)
                    {
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
                  
                    break;
                }

            case ("�� ����"):
                {
                    if (jongronpcM.clothesfirst == 1)
                    {
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

                    break;
                }


            case ("������"):
                {
                    
                    
                        ShopUI.SetActive(true);

                        if (SellManager.instance != null)
                        {
                            SellManager.instance.putinlist(Items);
                        }
                        else
                        {
                            Debug.LogError("SellManager �ν��Ͻ��� ã�� �� �����ϴ�.");
                        }
                    

                    break;
                }

            default:
                {
                    break;
                }

        }

    }


  
}
