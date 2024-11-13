using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth;   // ���� ü��
    public Slider healthBar;    // ü�� UI (Slider ���)

    void Start()
    {
        currentHealth = maxHealth; // ���� �� ü���� �ִ� ü������ ����
        UpdateHealthUI();
    }

    // ü���� ���ҽ�Ű�� �Լ�
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �������� ����
        Debug.Log("���� ü��: " + currentHealth); // ü�� �α� ���

        UpdateHealthUI(); // ü�� UI ������Ʈ

        if (currentHealth <= 0)
        {
            GameOver(); // ü���� 0 ������ �� ���ӿ��� ó��
        }
    }

    // ü�� UI ������Ʈ �Լ�
    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // ü�� �����̴� ������Ʈ
        }
    }

    // ���ӿ��� ó�� �Լ�
    void GameOver()
    {
        Debug.Log("Game Over!");
        // ���⼭ ���ӿ��� ó�� (��: ���ӿ��� UI, �� ����� ��)
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ����: ���� �� �ٽ� �ε�
    }
}
