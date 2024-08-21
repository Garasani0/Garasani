using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text textDisplay;  // TextMeshPro �ؽ�Ʈ�� ����� ���
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;

    // ���ο� �ؽ�Ʈ�� �ڵ����� �޾ƿͼ� Ÿ���� ȿ���� ����
    public void SetText(string newText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // ���� �ڷ�ƾ ����
        }
        typingCoroutine = StartCoroutine(TypeText(newText));
    }

    IEnumerator TypeText(string fullText)
    {
        textDisplay.text = ""; // �ؽ�Ʈ �ʱ�ȭ
        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
