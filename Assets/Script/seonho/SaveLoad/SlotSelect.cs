using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotSelect : MonoBehaviour
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

        // �ʱ� ���´� UI�� ��Ȱ��ȭ
        slotSelectionPanel.SetActive(false);
    }

    public void Show()
    {
        // ���� ��ư �ؽ�Ʈ ������Ʈ
        UpdateSlotButtons();
        slotSelectionPanel.SetActive(true);
    }

    void OnSlotButtonClicked(int slotNumber)
    {
        if (SaveLoadManager.instance.IsSlotUsed(slotNumber))
        {
            // ����� ���·� ���� ����
            SaveLoadManager.GameState gameState = SaveLoadManager.instance.LoadGame(slotNumber);
            if (gameState != null)
            {
                PlayerController.instance.transform.position = gameState.playerPosition;
                // �߰������� �ʿ��� �����Ͱ� ������ ���⼭ ����

                // UI�� ����� ���� ����
                slotSelectionPanel.SetActive(false);
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                Debug.LogError("���� ���¸� �ҷ����� �� �����߽��ϴ�.");
            }
        }
        else
        {
            Debug.Log("�� ������ �����߽��ϴ�. �ƹ� �ϵ� �Ͼ�� �ʽ��ϴ�.");
        }
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