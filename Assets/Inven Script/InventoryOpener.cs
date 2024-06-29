using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject inventoryWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 'e' Ű�� ������ �κ��丮 â�� ���ϴ�.
            inventoryWindow.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 'escape' Ű�� ������ �κ��丮 â�� �ݽ��ϴ�.
            inventoryWindow.SetActive(false);
        }
    }
}
