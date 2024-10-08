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

    // 체력을 감소시키는 함수
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("현재 체력: " + currentHealth);


        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    // 게임오버 처리 함수
    void GameOver()
    {
        Debug.Log("Game Over!");
        // 여기서 게임오버 처리 (예: 게임오버 UI, 씬 재시작 등)
    }
}
