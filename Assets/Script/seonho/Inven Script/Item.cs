using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;  // 아이템 이름
    public Sprite itemSprite;   // 아이템의 이미지 (Texture2D)
    public string itemDescription;  // 아이템 설명
    public bool isEquipable;  // 장착 가능한 아이템인지 여부
    public int itemCount;  // 아이템 개수
    public int itemPrice;  // 아이템 가격 (판매용)

    // 아이템을 판매할 수 있는지 확인
    public bool CanSell()
    {
        return itemPrice > 0;
    }
}