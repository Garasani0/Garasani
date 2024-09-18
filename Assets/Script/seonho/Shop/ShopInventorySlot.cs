using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInventorySlot : MonoBehaviour
{
    public TMP_Text itemNameText;  // ������ �̸�
    public TMP_Text itemPriceText;  // ������ ����
    public GameObject descriptionUI;  // ������ ���� UI
    private Item currentItem;  // ���� ���Կ� �ִ� ������
    private float clickTime = 0.0f;
    private float clickDelay = 0.25f;
    private bool isDoubleClick = false;

    private void Start()
    {
        descriptionUI.SetActive(false);  // ó������ ���� UI ��Ȱ��ȭ
    }

    // ���Կ� ������ ����
    public void SetItem(Item newItem)
    {
        currentItem = newItem;
        // ���� ���Կ� ������ ������ ǥ���� �� �ֵ��� ����
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
            StartCoroutine(SingleClick());
        }

        clickTime = currentTime;
    }

    // �̱� Ŭ�� �� ������ �̸��� ���� ǥ��
    private System.Collections.IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            itemNameText.text = currentItem.itemName;
            itemPriceText.text = currentItem.itemPrice.ToString();  // ���� ǥ��
            descriptionUI.SetActive(true);  // ���� UI Ȱ��ȭ
        }
    }

    // ����Ŭ�� �� ������ �Ǹ�
    private void OnDoubleClick()
    {
        if (currentItem != null)
        {
            // �Ǹ� ó�� (���� �Ŵ������� ó��)
            Debug.Log(currentItem.itemName + "��(��) �Ǹ��߽��ϴ�.");
            SellItem();
        }
    }

    // ������ �Ǹ� ó��
    private void SellItem()
    {
        GameManager.instance.SellItem(currentItem);  // GameManager���� �Ǹ� ó��
        descriptionUI.SetActive(false);  // ���� UI ��Ȱ��ȭ
    }
}