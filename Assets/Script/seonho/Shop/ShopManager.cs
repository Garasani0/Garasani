using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // ���� UI
    public ShopSlot[] shopSlots;  // �������� ����� ���� �迭
    public Image backgroundOverlay;  // ����� ��Ӱ� ó���� �������� �̹���
    public float backgroundOpacity = 0.5f;  // ��� ����

    private void Start()
    {
        shopUI.SetActive(false);
        InitializeShopSlots();
    }

    private void Update()
    {
        // ESC Ű�� ������ �� ���� UI�� �ݱ�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }

    // ���� ������Ʈ Ŭ�� �� ���� UI�� ���
    public void OpenShop()
    {
        Debug.Log("OpenShop called");
        shopUI.SetActive(true);
        SetBackgroundOpacity(true);  // ��� ��Ӱ� ó��
    }

    // ���� UI �ݱ�
    public void CloseShop()
    {
        shopUI.SetActive(false);
        SetBackgroundOpacity(false);  // ��� ��� ����
    }

    // ����� ���۽�Ƽ�� �����ϴ� �Լ�
    private void SetBackgroundOpacity(bool isActive)
    {
        if (isActive)
        {
            backgroundOverlay.color = new Color(0, 0, 0, backgroundOpacity);
        }
        else
        {
            backgroundOverlay.color = new Color(0, 0, 0, 0);  // ��� ��� ����
        }
    }

    // ���� ���Կ� GameManager���� �������� ������ ����
    private void InitializeShopSlots()
    {
        List<Item> gameItems = GameManager.instance.GetShopItems(); // GameManager���� ������ ��� ������

        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < gameItems.Count)  // �������� ���� ������ ������ ����
            {
                shopSlots[i].SetItem(gameItems[i]);
            }
            else
            {
                shopSlots[i].ClearSlot();  // �� ������ �����
            }
        }
    }

    // �������� �Ǹ��ϴ� �޼���
    public void SellItem(int slotIndex)
    {
        // �ε����� ��ȿ���� Ȯ��
        if (slotIndex < 0 || slotIndex >= shopSlots.Length)
        {
            Debug.LogError("Invalid slot index");
            return;
        }

        // ���Կ��� ������ ��������
        ShopSlot slot = shopSlots[slotIndex];
        if (slot == null || slot.IsEmpty())
        {
            Debug.LogError("Slot is empty or does not exist");
            return;
        }

        Item itemToSell = slot.GetItem();
        if (itemToSell == null)
        {
            Debug.LogError("Item to sell is null");
            return;
        }

        int itemPrice = itemToSell.itemPrice;  // ������ ���� ��������
        GameManager.instance.RemoveItem(itemToSell);  // GameManager���� ������ ����
        GameManager.instance.AddGold(itemPrice);  // GameManager�� ��� �߰�

        // ���� ����
        slot.ClearSlot();
    }
}