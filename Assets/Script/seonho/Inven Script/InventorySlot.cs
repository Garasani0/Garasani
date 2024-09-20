using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;  // ������ �̹����� ��Ÿ�� UI ������Ʈ
    public GameObject[] itemCountImages;  // ������ �̹��� �迭 (1~12)
    public TMP_Text itemNameText;         // ������ �̸� �ؽ�Ʈ
    public TMP_Text itemDescriptionText;  // ������ ���� �ؽ�Ʈ
    public GameObject descriptionUI;      // ���� UI

    private Item currentItem;  // ���� ������ ������
    private float clickTime = 0.0f;  // Ŭ�� �ð�
    private float clickDelay = 0.5f;  // ����Ŭ�� �ν� �ð� ����
    private bool isDoubleClick = false;

    void Start()
    {
        descriptionUI.SetActive(false);  // ó���� ���� UI�� ��Ȱ��ȭ
    }

    // ���Կ� ������ ����
    public void SetItem(Item newItem)
    {
        currentItem = newItem;
        UpdateItemCount(newItem.itemCount);
        itemImage.sprite = newItem.itemSprite;
        itemImage.gameObject.SetActive(true); // �������� ���� ��� �̹����� ���̰� ����
    }

    // ������ ����ִ��� Ȯ��
    public bool IsEmpty()
    {
        return currentItem == null;
    }

    // ������ ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
    public void UpdateItemCount(int count)
    {
        for (int i = 0; i < itemCountImages.Length; i++)
        {
            itemCountImages[i].SetActive(i == count - 1);  // �´� ���� �̹����� Ȱ��ȭ
        }
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

    // �̱�Ŭ�� ó�� (���� UI ǥ��)
    private System.Collections.IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            // ���� ���� UI�� ���� ������ �Ѱ�, ���� ������ ���� ������� ���
            descriptionUI.SetActive(!descriptionUI.activeSelf);

            if (descriptionUI.activeSelf)
            {
                itemNameText.text = currentItem.itemName;
                itemDescriptionText.text = currentItem.itemDescription;
            }
        }
    }

    // ����Ŭ���ϸ� ������ ����
    private void OnDoubleClick()
    {
        if (currentItem != null && currentItem.isEquipable)
        {
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            inventory.EquipItem(currentItem);  // ������ �������� InventoryManager���� ����

            // ���� �� ���� UI�� ��Ȱ��ȭ
            descriptionUI.SetActive(false);
        }
    }

    public void ClearSlot()
    {
        currentItem = null;
        itemImage.sprite = null;
        itemNameText.text = "";
        itemDescriptionText.text = "";
    }
}