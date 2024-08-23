using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gifimage : MonoBehaviour
{
    public Sprite[] images; // ������ �̹������� ���� �迭
    public Image displayImage; // �̹����� ǥ���� UI Image ������Ʈ

    private int currentIndex = 0; // ���� ǥ�� ���� �̹����� �ε���

    void Start()
    {
        if (images.Length > 0)
        {
            StartCoroutine(ChangeImage());
        }
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            // �̹��� ����
            displayImage.sprite = images[currentIndex];

            // ���� �̹����� �ε��� ���� (��ȯ)
            currentIndex = (currentIndex + 1) % images.Length;

            // 0.5�� ���
            yield return new WaitForSeconds(0.5f);
        }
    }
}
