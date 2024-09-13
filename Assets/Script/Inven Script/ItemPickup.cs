using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // �ֿ� ������ ������

    private void OnMouseDown()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
            inventoryManager.AddItemToSlot(item);
            Destroy(gameObject); // ������ ������Ʈ�� ���ӿ��� ����
        }
    }
}