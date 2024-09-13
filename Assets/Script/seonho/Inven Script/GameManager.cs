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

    public void SellItem(Item item)
    {
        playerMoney += item.itemPrice;  // �Ǹ� ���ݸ�ŭ ��� �߰�
        Debug.Log("�Ǹ� �Ϸ�: " + item.itemName);
        // �κ��丮���� �ش� ������ ���� ���� �߰� ����
    }
}