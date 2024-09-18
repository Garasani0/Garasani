using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;  // ������ �̸�
    public Sprite itemSprite;   // �������� �̹��� (Texture2D)
    public string itemDescription;  // ������ ����
    public bool isEquipable;  // ���� ������ ���������� ����
    public int itemCount;  // ������ ����
    public int itemPrice;  // ������ ���� (�Ǹſ�)

    // �������� �Ǹ��� �� �ִ��� Ȯ��
    public bool CanSell()
    {
        return itemPrice > 0;
    }
}