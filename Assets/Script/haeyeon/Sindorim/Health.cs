using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // ü���� ���ҽ�Ű�� �Լ�
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("���� ü��: " + currentHealth);


        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    // ���ӿ��� ó�� �Լ�
    void GameOver()
    {
        Debug.Log("Game Over!");
        // ���⼭ ���ӿ��� ó�� (��: ���ӿ��� UI, �� ����� ��)
    }
}
