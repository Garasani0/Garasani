using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string playername = "Player";
    public string nextSceneName;  // �̵��� ���� �̸�

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playername)
        {
            Debug.Log("���̵�");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}