using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    public Item[] items;
    public InventorySlot[] inventory = new InventorySlot[5];
    public GameObject inventoryUI;
    public Image[] inventoryImages;
    public Text[] inventoryCountTexts;

    // ���� ���� UI ��ҵ�
    public Image equippedItemImage;
    public Text equippedItemName;
    public Text equippedItemDescription;

    // ���� ���� ���¸� ��Ÿ���� UI ��ҵ�
    public Image[] slotBackgrounds;
    public Sprite selectedSlotBackground;
    public Sprite defaultSlotBackground;

    private int equippedItemIndex = -1;
    private int selectedSlotIndex = -1;
    private float lastClickTime;
    private const float doubleClickTime = 0.3f;

    void Start()
    {
        // �κ��丮 �ʱ�ȭ
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = new InventorySlot(-1, 0);
        }

        // UI �ʱ�ȭ
        UpdateInventoryUI();
        ClearEquippedItemUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddRandomItem();
        }

        if (Input.GetKeyDown(KeyCode.X) && equippedItemIndex != -1)
        {
            DiscardEquippedItem();
        }
    }

    public void OnInventorySlotClick(int slotIndex)
    {
        float currentTime = Time.time;
        if (currentTime - lastClickTime < doubleClickTime)
        {
            EquipItem(slotIndex);
            UpdateSlotSelection(slotIndex);
        }
        lastClickTime = currentTime;
    }

    void AddRandomItem()
    {
        int randomIndex = Random.Range(0, items.Length);

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].itemIndex == randomIndex)
            {
                // �̹� �����ϴ� ������
                inventory[i].count++;
                UpdateInventoryUI();
                return;
            }
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].itemIndex == -1)
            {
                // �� ���� �߰�
                inventory[i] = new InventorySlot(randomIndex, 1);
                UpdateInventoryUI();
                return;
            }
        }

        // �κ��丮�� ���� �� ���
        Debug.Log("�κ��丮�� ���� á���ϴ�.");
    }

    void EquipItem(int slotIndex)
    {
        if (inventory[slotIndex].itemIndex != -1)
        {
            equippedItemIndex = slotIndex;
            Item item = items[inventory[slotIndex].itemIndex];
            equippedItemImage.sprite = item.image;
            equippedItemName.text = item.name;
            equippedItemDescription.text = item.description;
            equippedItemImage.gameObject.SetActive(true);
        }
    }

    void DiscardEquippedItem()
    {
        if (equippedItemIndex != -1)
        {
            inventory[equippedItemIndex].count--;
            if (inventory[equippedItemIndex].count <= 0)
            {
                inventory[equippedItemIndex] = new InventorySlot(-1, 0);
                equippedItemIndex = -1;
                ClearEquippedItemUI();
                ClearSlotSelection();
            }
            UpdateInventoryUI();
        }
    }

    void ClearEquippedItemUI()
    {
        equippedItemImage.gameObject.SetActive(false);
        equippedItemName.text = "";
        equippedItemDescription.text = "";
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].itemIndex != -1)
            {
                inventoryImages[i].sprite = items[inventory[i].itemIndex].image;
                inventoryImages[i].gameObject.SetActive(true);
                inventoryCountTexts[i].text = inventory[i].count.ToString();
                inventoryCountTexts[i].gameObject.SetActive(inventory[i].count > 1);
            }
            else
            {
                inventoryImages[i].gameObject.SetActive(false);
                inventoryCountTexts[i].gameObject.SetActive(false);
            }
        }
    }

    void UpdateSlotSelection(int slotIndex)
    {
        if (selectedSlotIndex != -1)
        {
            slotBackgrounds[selectedSlotIndex].sprite = defaultSlotBackground;
        }

        selectedSlotIndex = slotIndex;
        slotBackgrounds[selectedSlotIndex].sprite = selectedSlotBackground;
    }

    void ClearSlotSelection()
    {
        if (selectedSlotIndex != -1)
        {
            slotBackgrounds[selectedSlotIndex].sprite = defaultSlotBackground;
            selectedSlotIndex = -1;
        }
    }
}

