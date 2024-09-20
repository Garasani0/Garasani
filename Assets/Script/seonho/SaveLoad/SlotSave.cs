using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSave : MonoBehaviour
{
    public GameObject slotSelectionPanel; // ���� ���� UI �г�
    public Button[] slotButtons; // ���� ��ư �迭
    public Button closeButton; // �ݱ� ��ư

    private void Start()
    {
        // ���� ��ư Ŭ�� �̺�Ʈ ����
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int slotNumber = i + 1; // ���� ��ȣ ����
            slotButtons[i].onClick.AddListener(() => OnSlotButtonClicked(slotNumber));
        }

        // �ݱ� ��ư Ŭ�� �̺�Ʈ ����
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void Show()
    {
        // ���� ��ư �ؽ�Ʈ ������Ʈ
        UpdateSlotButtons();
        slotSelectionPanel.SetActive(true);
    }

    public void OnSlotButtonClicked(int slotNumber)
    {
        // ���� ���� ���¸� �����ͼ� ����
        SaveLoadManager.GameState gameState = new SaveLoadManager.GameState
        {
            playerPosition = PlayerController.instance.transform.position
        };

        SaveLoadManager.instance.SaveGame(slotNumber, gameState);

        Debug.Log("���� " + slotNumber + "�� ����Ǿ����ϴ�.");
    }

    void OnCloseButtonClicked()
    {
        // UI�� ����
        slotSelectionPanel.SetActive(false);
    }

    void UpdateSlotButtons()
    {
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int slotNumber = i + 1;
            if (SaveLoadManager.instance.IsSlotUsed(slotNumber))
            {
                slotButtons[i].GetComponentInChildren<Text>().text = "Slot " + slotNumber + " (Used)";
            }
            else
            {
                slotButtons[i].GetComponentInChildren<Text>().text = "Slot " + slotNumber + " (Empty)";
            }
        }
    }
}