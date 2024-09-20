using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;  // ������ �̹���
    public TMP_Text itemNameText;  // ������ �̸�
    public TMP_Text itemPriceText;  // ������ ����
    public TMP_Text itemDescriptionText;  // ������ ����
    public Item item;  // �� ���Կ� �ش��ϴ� ������

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;  // ���� ������ ����
    }

    // ������ ����
    public void SetItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = newItem.itemSprite;
        itemNameText.text = newItem.itemName;
        itemPriceText.text = newItem.itemPrice.ToString();
        itemDescriptionText.text = newItem.itemDescription;
    }

    // Ŭ�� �̺�Ʈ ó��
    public void OnClick()
    {
        // ���� ó��
        if (GameManager.instance.playerMoney >= item.itemPrice)
        {
            GameManager.instance.AddItem(item);  // ������ �߰�
            GameManager.instance.RemoveGold(item.itemPrice);  // �� ����
            Debug.Log("���� �Ϸ�: " + item.itemName);
            // �߰� UI ������Ʈ ����...
        }
        else
        {
            Debug.Log("���� �����մϴ�.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("���콺�� ���Կ� �����ϴ�.");  // �α� �߰�
        transform.localScale = originalScale * 1.1f;  // ũ�� Ű���
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("���콺�� ���Կ��� �������ϴ�.");  // �α� �߰�
        transform.localScale = originalScale;  // ���� ũ��� �ǵ�����
    }
}