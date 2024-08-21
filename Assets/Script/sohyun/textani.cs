using UnityEngine;
using TMPro;
using System.Collections;

public class textani : MonoBehaviour
{

    public TMP_Text textDisplay;  // TextMeshPro�� ����� ���
    // public Text textDisplay;  // �⺻ UI �ؽ�Ʈ�� ����� ���
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ� ����

    private Coroutine typingCoroutine;

    public void DisplayDialogue(string dialogue)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // ���� �ڷ�ƾ ����
        }
        typingCoroutine = StartCoroutine(TypeText(dialogue));
    }

    private IEnumerator TypeText(string text)
    {
        textDisplay.text = ""; // �ؽ�Ʈ �ʱ�ȭ
        foreach (char letter in text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Ÿ���� �ӵ� ����
        }
    }

}
