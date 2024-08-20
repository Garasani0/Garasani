using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public string playerName = "Player"; // �÷��̾� ������Ʈ�� �̸�
    private GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        player = GameObject.Find(playerName);

        if (player != null)
        {
            Invoke("HideCanvas", 3f);
        }
        else
        {
            Debug.LogError($"�÷��̾� ������Ʈ '{playerName}'��(��) ã�� �� �����ϴ�.");
        }
    }

    void HideCanvas()
    {

        // ĵ���� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}