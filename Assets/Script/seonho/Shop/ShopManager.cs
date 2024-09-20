using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // ���� UI
    public ShopSlot[] shopSlots;  // �������� ����� ���� �迭

    private void Start()
    {
        InitializeShopSlots();
    }

    private void Update()
    {
        // ESC Ű�� ������ �� ���� UI�� �ݱ�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopUI.SetActive(false);
            Player.moveflag = 1;
        }
        InitializeShopSlots();
    }

    private void InitializeShopSlots()
    {
        List<Item> inventoryItems = GameManager.instance.inventoryItems;

        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                shopSlots[i].SetItem(inventoryItems[i]);
            }
            else
            {
                shopSlots[i].ClearSlot();
            }
        }
    }

    // �������� �Ǹ��ϴ� �޼���
    public void SellItem(int slotIndex)
    {
        Debug.Log("�Ǹ� �õ� ���� �ε���: " + slotIndex);

        if (slotIndex < 0 || slotIndex >= shopSlots.Length)
        {
            Debug.LogError("��ȿ���� ���� ���� �ε���");
            return;
        }

        ShopSlot slot = shopSlots[slotIndex];
        if (slot.IsEmpty())
        {
            Debug.LogError("��� �ִ� �����Դϴ�."); // �� �޽����� �ߴ� ���� Ȯ��
            return;
        }

        Item itemToSell = slot.GetItem();
        if (itemToSell != null)
        {
            GameManager.instance.SellItem(itemToSell); // �������� GameManager���� �Ǹ�
            slot.ClearSlot(); // ���� ����
            InitializeShopSlots(); // ���� ���� ������Ʈ
        }
    }
}