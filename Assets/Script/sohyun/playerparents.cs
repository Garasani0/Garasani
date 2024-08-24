using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;
public class playerparents : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        GameObject basebody = GameObject.Find("basebody");

        // ���� ��ü�� basebody�� �θ����� Ȯ��
        if (basebody.transform.parent == transform)
        {
            // basebody�� x, y ��ǥ�� Vector2�� ����
            Vector2 position = new Vector2(basebody.transform.position.x, basebody.transform.position.y);

            // z ���� 0���� �Ͽ� Vector3�� ��ȯ
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }

    }
}
