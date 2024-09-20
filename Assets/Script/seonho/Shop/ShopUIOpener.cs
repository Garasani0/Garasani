using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopUIOpener : MonoBehaviour
{
    public GameObject shopUI;  // ShopManager ����

    void Start()
    {
        shopUI.SetActive(false); // ���� ���� �� UI ��Ȱ��ȭ
    }

    void OnMouseDown()
    {
        shopUI.SetActive(!shopUI.activeSelf);
        Player.moveflag = 0;
    }
}