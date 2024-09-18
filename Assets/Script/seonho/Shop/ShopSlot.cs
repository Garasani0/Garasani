using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image itemImage;  // ������ �̹����� ��Ÿ�� UI ������Ʈ
    public TMP_Text itemNameText;  // ������ �̸� �ؽ�Ʈ
    public TMP_Text itemPriceText;  // ������ ���� �ؽ�Ʈ
    public GameObject descriptionUI;  // ������ ���� UI
    public float descriptionDuration = 3f;  // ���� UI ǥ�� �ð�

    private Item currentItem;  // ���� ������ ������
    private float clickTime = 0.0f;  // Ŭ�� �ð�
    private float clickDelay = 0.25f;  // ����Ŭ�� �ν� �ð� ����
    private bool isDoubleClick = false;

    void Start()
    {
        descriptionUI.SetActive(false);  // ó���� ���� UI�� ��Ȱ��ȭ
    }

    // ���Կ� ������ ����
    public void SetItem(Item newItem)
    {
        currentItem = newItem;
        itemImage.sprite = newItem.itemSprite;
        itemNameText.text = newItem.itemName;
        itemPriceText.text = newItem.itemPrice.ToString();  // ������ ���� ����
    }

    // ������ ����ִ��� Ȯ��
    public bool IsEmpty()
    {
        return currentItem == null;
    }

    // ������ ��������
    public Item GetItem()
    {
        return currentItem;
    }

    // ���� Ŭ�� ��
    public void OnClick()
    {
        if (currentItem == null) return; // �������� ���� ��� ����

        float currentTime = Time.time;
        float timeSinceLastClick = currentTime - clickTime;

        if (timeSinceLastClick <= clickDelay)
        {
            isDoubleClick = true;
            OnDoubleClick();  // ����Ŭ������ ����
        }
        else
        {
            isDoubleClick = false;
            StartCoroutine(SingleClick());  // �̱�Ŭ�� ó��
        }

        clickTime = currentTime;
    }

    // �̱�Ŭ�� ó�� (���� UI ǥ��)
    private IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            descriptionUI.SetActive(true);  // ���� UI Ȱ��ȭ
            yield return new WaitForSeconds(descriptionDuration);  // 3�� ��ٸ�
            descriptionUI.SetActive(false);  // ���� UI ��Ȱ��ȭ
        }
    }

    // ����Ŭ���ϸ� ������ �Ǹ�
    private void OnDoubleClick()
    {
        if (currentItem != null)
        {
            ShopManager shopManager = FindObjectOfType<ShopManager>();
            if (shopManager != null)
            {
                int slotIndex = Array.IndexOf(FindObjectsOfType<ShopSlot>(), this);  // ���� ���� �ε��� ã��
                shopManager.SellItem(slotIndex);  // ������ �������� ShopManager���� ����
            }
        }
    }

    // ���� ����
    public void ClearSlot()
    {
        currentItem = null;
        itemImage.sprite = null;
        itemNameText.text = "";
        itemPriceText.text = "";
    }
}