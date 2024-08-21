using UnityEngine;
using TMPro;
using System.Collections;

public class textani : MonoBehaviour
{
    public TMP_Text textComponent;  // TextMeshPro �ؽ�Ʈ ������Ʈ
    public float typingSpeed = 0.05f;  // Ÿ���� �ӵ� ����

    private string fullText;  // ��ü �ؽ�Ʈ

    void Start()
    {
        if (textComponent != null)
        {
            fullText = textComponent.text;  // �ؽ�Ʈ ������Ʈ���� ��ü �ؽ�Ʈ ��������
            textComponent.text = "";  // �ؽ�Ʈ�� �ʱ�ȭ�Ͽ� �� ���·� ����
            StartCoroutine(TypeText());  // �ڷ�ƾ ����
        }
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            textComponent.text += letter;  // �� ���ھ� �ؽ�Ʈ�� �߰�
            yield return new WaitForSeconds(typingSpeed);  // Ÿ���� �ӵ��� ���� ���
        }
    }

}
