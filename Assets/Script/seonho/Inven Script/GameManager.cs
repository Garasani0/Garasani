using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerMoney=5000;
    public bool nomoney = false;
   
    public List<Item> inventoryItems = new List<Item>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item newItem)
    {
        inventoryItems.Add(newItem);
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (inventoryItems.Contains(itemToRemove))
        {
            inventoryItems.Remove(itemToRemove);
        }
    }
    public bool SearchItem(string itemname)
    {
        foreach(Item item in inventoryItems)
        {
            if(item.name == itemname)
            {
                return true;
            }
            
        }
        return false;
    }
    public void RemoveItemString(string itemname)
    {
       
        List<Item> itemsToRemove = new List<Item>();
        foreach (Item item in inventoryItems)
        {
            if (item.name == itemname)
            {
                itemsToRemove.Add(item);
            }
        }

        foreach (Item item in itemsToRemove)
        {
            inventoryItems.Remove(item);
        }
    }
    public void RemoveItemRandom()
    {
        if(inventoryItems.Count>0)
        {

            List<Item> itemsToRemove = new List<Item>();
            int randomint = Random.Range(0, inventoryItems.Count);
            itemsToRemove.Add(inventoryItems[randomint]);


            foreach (Item item in itemsToRemove)
            {
                inventoryItems.Remove(item);
            }
        }
      
    }
    public void AddGold(int amount)
    {
        playerMoney += amount;
        Debug.Log("��� �߰�: " + amount);
    }

    public List<Item> GetShopItems()
    {
        // ������ ǥ���� �������� ��ȯ�ϴ� �޼���
        return inventoryItems;
    }

    // �Ǹ��� �� ȣ��Ǵ� �޼���
    public void SellItem(Item item)
    {
        // �������� �κ��丮���� �����ϰ� ��带 �߰�
        RemoveItem(item);
        AddGold(item.itemPrice);
        Debug.Log("������ �Ǹ� �Ϸ�: " + item.itemName);
    }

    public void RemoveGold(int amount)
    {
        if(playerMoney-amount<0)
        {
            nomoney = true;
            Debug.Log("���� �����ϴ�");
        }
        else
        {
            nomoney = false;
            playerMoney -= amount;
            Debug.Log("��� ����: " + amount);
        }
      
    }
}