using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName;  // �̵��� ���� �̸�

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            SceneManager.LoadScene(targetSceneName);  // �� �̵�
        }
    }
}