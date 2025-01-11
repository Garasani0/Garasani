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
            case ("델리만쥬 가게"):
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
                            Debug.LogError("SellManager 인스턴스를 찾을 수 없습니다.");
                        }
                    }
                  
                    break;
                }

            case ("옷 가게"):
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
                            Debug.LogError("SellManager 인스턴스를 찾을 수 없습니다.");
                        }
                    }

                    break;
                }


            case ("편의점"):
                {
                    
                    
                        ShopUI.SetActive(true);

                        if (SellManager.instance != null)
                        {
                            SellManager.instance.putinlist(Items);
                        }
                        else
                        {
                            Debug.LogError("SellManager 인스턴스를 찾을 수 없습니다.");
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
