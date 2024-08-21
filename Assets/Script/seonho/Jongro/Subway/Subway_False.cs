using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Subway_False : MonoBehaviour
{
    public Image image;
    public Image fadeInImage; // õõ�� ���� �̹���
    public float displayDuration = 5f; // �̹��� ǥ�� �ð�
    public float fadeInDuration = 2f; // ���̵� �� �ð�
    public string nextSceneName; // �̵��� �� �̸�

    private void Start()
    {
        Player.moveflag = 0;
        fadeInImage.canvasRenderer.SetAlpha(0f);
        StartCoroutine(HandleSceneTransition());
    }

    IEnumerator HandleSceneTransition()
    {
        image.gameObject.SetActive(true);

        // 5�� ��ٸ���
        yield return new WaitForSeconds(displayDuration);

        // ���� Ȱ��ȭ�� �̹����� ��Ȱ��ȭ
        image.gameObject.SetActive(false);

        // ���̵� �� �̹��� �ʱ� ���� ����
        fadeInImage.gameObject.SetActive(true);

        // ���̵� �� �ִϸ��̼�
        fadeInImage.CrossFadeAlpha(1f, fadeInDuration, false); // õõ�� ���̰� �����

        // ���̵� �� �Ϸ� ���
        yield return new WaitForSeconds(fadeInDuration);

        // �� �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}