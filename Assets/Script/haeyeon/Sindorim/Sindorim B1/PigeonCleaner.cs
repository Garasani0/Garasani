using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonCleaner : MonoBehaviour
{
    // ���� ������ ����
    public static void CleanUp(GameObject pigeon)
    {
        if (pigeon != null)
        {
            GameObject.Destroy(pigeon);  // ���� ȣ���� UnityEngine ���ӽ����̽��� ����
        }
    }
}