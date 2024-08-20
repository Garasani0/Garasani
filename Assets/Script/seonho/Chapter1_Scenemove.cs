using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1_Scenemove : MonoBehaviour
{
    public string playername = "eye";
    public string nextSceneName = "3ȣ���°���_����"; // �̵��� �� �̸�
    public Image fadeImage; // ȭ���� ��Ӱ� �� �̹���
    public float fadeDuration = 2f; // ȭ���� ��ο����� �� �ɸ��� �ð�

    private bool isFading = false;

    void Start()
    {
        // ������ �� �̹����� ���İ��� 0���� ����
        SetFadeImageAlpha(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹 �߻�: " + other.gameObject.name); // �浹�� �߻��� ���� ������Ʈ �̸��� ���

        // �̸��� "Player"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        if (other.gameObject.name == playername && !isFading)
        {
            Debug.Log("�÷��̾�� �浹 ������!"); // �÷��̾�� �浹�� �����Ǿ����� ���
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        isFading = true;

        // �̹��� Ȱ��ȭ
        fadeImage.gameObject.SetActive(true);

        // ȭ���� õõ�� ��ο����� �ϱ�
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            SetFadeImageAlpha(alpha);
            yield return null;
        }

        SetFadeImageAlpha(1);
        Debug.Log("�� �̵� ��...");
        // �� �̵�
        SceneManager.LoadScene(nextSceneName);
    }

    void SetFadeImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}