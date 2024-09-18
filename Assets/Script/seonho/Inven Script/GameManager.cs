using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerMoney;
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
}