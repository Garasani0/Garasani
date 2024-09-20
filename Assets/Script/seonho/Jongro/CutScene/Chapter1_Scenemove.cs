using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1_Scenemove : MonoBehaviour
{
    public string playername = "hair (2)";
    public string nextSceneName = "3ȣ���°���_����"; // �̵��� �� �̸�
    public Image fadeImage; // ȭ���� ��Ӱ� �� �̹���
    public float fadeDuration = 2f; // ȭ���� ��ο����� �� �ɸ��� �ð�

    public AudioClip audioClip; // ����� �ҽ�
    public float audioFadeDuration = 0.7f; // ����� ���̵�ƿ� �ð�
    private AudioSource audioSource;

    private bool isFading = false;

    public Transform objectToMove;

    void Start()
    {
        // ������ �� �̹����� ���İ��� 0���� ����
        SetFadeImageAlpha(0);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹 �߻�: " + other.gameObject.name); // �浹�� �߻��� ���� ������Ʈ �̸��� ���

        // �̸��� "Player"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        if (other.gameObject.name == playername && !isFading)
        {
            Debug.Log("�÷��̾�� �浹 ������!"); // �÷��̾�� �浹�� �����Ǿ����� ���
            Player.moveflag = 0;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        isFading = true;

        yield return MoveObject();

        fadeImage.gameObject.SetActive(true);
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            SetFadeImageAlpha(alpha);
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / audioFadeDuration);
            yield return null;
        }

        SetFadeImageAlpha(1);
        audioSource.volume = 0;

        Debug.Log("�� �̵� ��...");
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator MoveObject()
    {
        float moveDuration = 3f;
        float elapsedTime = 0f;

        Vector3 startPosition = objectToMove.position;
        Vector3 endPosition = startPosition + new Vector3(startPosition.x + 5, startPosition.y, startPosition.z);

        // ������Ʈ �̵�
        while (elapsedTime < moveDuration)
        {
            objectToMove.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���� ��ġ�� ����
        objectToMove.position = endPosition;
    }

    void SetFadeImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}