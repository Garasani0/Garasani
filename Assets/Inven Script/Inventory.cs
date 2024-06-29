using UnityEngine;
using TMPro;

[System.Serializable]
public struct Item
{
    public string name;
    public string info;
}

[System.Serializable]
public struct Slot
{
    public string itemName;
    public string itemInfo;
    public int quantity;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI itemInfoText;
}

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[6];
    public Slot[] slots = new Slot[5];

    void Start()
    {
        items[0] = new Item { name = "��1", info = "����1" };
        items[1] = new Item { name = "��2", info = "����2" };
        items[2] = new Item { name = "��3", info = "����3" };
        items[3] = new Item { name = "��4", info = "����4" };
        items[4] = new Item { name = "��5", info = "����5" };
        items[5] = new Item { name = "��6", info = "����6" };

        // �ʱ�ȭ �� ������ ������ �̸��� �� ���ڿ��� ����
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].itemName = "";
            slots[i].itemInfo = "";
            slots[i].quantity = 0;
            slots[i].itemText.text = "";
            slots[i].quantityText.text = "";
            slots[i].itemInfoText.text = "";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int randomIndex = Random.Range(0, items.Length);
            string newItemName = items[randomIndex].name;
            string newItemInfo = items[randomIndex].info; // ���ο� �������� ���� ��������

            bool itemAdded = false;

            // �̹� �ִ� ���������� Ȯ��
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemName == newItemName)
                {
                    slots[i].quantity++;
                    slots[i].quantityText.text = slots[i].quantity.ToString();
                    Debug.Log($"���� {i + 1}: {newItemName} (����: {slots[i].quantity})");
                    itemAdded = true;
                    break;
                }
            }

            // ���ο� �������̸� �� ���Կ� �߰�
            if (!itemAdded)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].itemName == "")
                    {
                        slots[i].itemName = newItemName;
                        slots[i].itemInfo = newItemInfo; // ������ ���� ����
                        slots[i].quantity = 1;
                        slots[i].itemText.text = newItemName;
                        slots[i].quantityText.text = "1";
                        slots[i].itemInfoText.text = newItemInfo; // ������ ���� UI�� ����
                        Debug.Log($"���� {i + 1}: {newItemName} (����: 1)");
                        break;
                    }
                }
            }
        }
    }
}
