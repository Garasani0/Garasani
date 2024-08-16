using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSave : MonoBehaviour
{
    public int slotNumber; // ���� ��ȣ�� ������ ����

    void OnMouseDown()
    {
        // ���� �� �̸��� SaveLoadManager�� ����
        SaveLoadManager.currentSceneName = SceneManager.GetActiveScene().name;

        // �÷��̾� ��ġ�� ���Կ� ����
        SaveLoadManager.GameState currentState = new SaveLoadManager.GameState
        {
            playerPosition = PlayerController.instance.transform.position
        };
        SaveLoadManager.instance.SaveGame(slotNumber, currentState);

        // UI�� ����
        gameObject.SetActive(false);
    }
}