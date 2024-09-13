using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // ���� UI
    public GameObject inventoryUI;  // ���ο� �κ��丮 UI
    public InventorySlot[] shopSlots;  // �������� ����� ���� �迭
    public Image backgroundOverlay;  // ����� ��Ӱ� ó���� �������� �̹���
    public TMP_Text itemNameText;  // ������ �̸� �ؽ�Ʈ
    public TMP_Text itemPriceText;  // ������ ���� �ؽ�Ʈ
    public float backgroundOpacity = 0.5f;  // ��� ����

    private void Start()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    // ���� ������Ʈ Ŭ�� �� ���� UI�� �κ��丮 UI�� ���
    public void OpenShop()
    {
        shopUI.SetActive(true);
        inventoryUI.SetActive(true);
        SetBackgroundOpacity(true);  // ��� ��Ӱ� ó��
    }

    // ���� UI �ݱ�
    public void CloseShop()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
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
}