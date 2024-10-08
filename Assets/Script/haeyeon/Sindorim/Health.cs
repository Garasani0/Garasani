using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    public int currentHealth;   // 현재 체력
    public Slider healthBar;    // 체력 UI (Slider 사용)

    void Start()
    {
        currentHealth = maxHealth; // 시작 시 체력을 최대 체력으로 설정
        UpdateHealthUI();
    }

    // 체력을 감소시키는 함수
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 데미지를 입음
        Debug.Log("현재 체력: " + currentHealth); // 체력 로그 출력

        UpdateHealthUI(); // 체력 UI 업데이트

        if (currentHealth <= 0)
        {
            GameOver(); // 체력이 0 이하일 때 게임오버 처리
        }
    }

    // 체력 UI 업데이트 함수
    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // 체력 슬라이더 업데이트
        }
    }

    // 게임오버 처리 함수
    void GameOver()
    {
        Debug.Log("Game Over!");
        // 여기서 게임오버 처리 (예: 게임오버 UI, 씬 재시작 등)
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 예시: 현재 씬 다시 로드
    }
}
