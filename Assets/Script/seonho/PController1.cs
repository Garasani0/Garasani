using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController1 : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            player.transform.position = new Vector3(-3,-1,0);
            Debug.Log("�÷��̾� ��ġ�� (0,0,0)���� �̵��Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogError("Player��� �̸��� ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }
}