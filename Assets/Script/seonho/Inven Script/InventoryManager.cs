using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;   // �κ��丮 UI
    public Transform playerUI;  // �÷��̾� ������Ʈ�� ��Ÿ�� ��ġ(UI)
    private GameObject playerInstance;  // ���� Player ������Ʈ �ν��Ͻ�
    public InventorySlot[] slots;    // 20���� ���� �迭

    public Image equippedItemImage;  // ������ ������ ����
    public TMP_Text equippedItemName;  // ������ ������ �̸�
    public TMP_Text equippedItemDescription;  // ������ ������ ����
    public bool isInventoryOpen = false; // �κ��丮 UI ����
    public Item equippedItem;

    private void Start()
    {
        inventoryUI.SetActive(false);
        UpdatePlayerImage();
        LoadInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
        if (isInventoryOpen)
        {
            LoadInventory(); // ������ ����Ʈ�� �ֱ������� ������Ʈ
        }
    }

    // ������ Player ������Ʈ�� ã�Ƽ� �÷��̾� UI�� �ݿ�
    void UpdatePlayerImage()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerInstance = Instantiate(player, playerUI);  // Player ������Ʈ�� �����Ͽ� UI�� ��ġ
            playerInstance.transform.localScale = Vector3.one;  // ������ ũ�� ���� (�ʿ�� ����)
        }
    }

    // �������� ���Կ� �߰��ϴ� �Լ�
    public void AddItemToSlot(Item newItem)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(newItem);
                GameManager.instance.AddItem(newItem);  // GameManager�� ������ �߰�
                break;
            }
        }
    }

    // �κ��丮 ����/�ݱ�
    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
    }

    // ������ ���� �Լ�
    public void EquipItem(Item newItem)
    {
        equippedItem = newItem;  // ���� ������ �������� �� ���������� ��ü

        // UI�� ������ ������ ���� ������Ʈ
        equippedItemImage.sprite = newItem.itemSprite;
        equippedItemName.text = newItem.itemName;
        equippedItemDescription.text = newItem.itemDescription;

        Debug.Log("������ ������: " + equippedItem.itemName);
    }

    // �� �̵� �� �κ��丮 ���� �ε�
    private void LoadInventory()
    {
        List<Item> inventoryItems = GameManager.instance.inventoryItems;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                slots[i].SetItem(inventoryItems[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // ���� �ε�� �� ȣ��Ǵ� �̺�Ʈ ���
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // �̺�Ʈ ����
    }

    // �� �̵� �� ������ ���¸� �ε��ϴ� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadInventory();  // ���� �ε�� �� �κ��丮 ���¸� �ε�
    }
}