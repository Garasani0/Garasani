using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIOpener : MonoBehaviour
{
    public ShopManager shopManager;  // ShopManager ����

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���콺 ���� ��ư Ŭ�� ��
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)  // Ŭ���� ������Ʈ�� ���� ������Ʈ���� Ȯ��
            {
                Debug.Log("ShopTrigger clicked");  // ����� �α� �߰�
                shopManager.OpenShop();  // ���� ����
            }
        }
    }
}