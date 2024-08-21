using UnityEngine;
using TMPro;

public class TextManager1 : MonoBehaviour
{
    public TypingEffect typingEffectScript;  // TypingEffect ��ũ��Ʈ ����
    public TMP_Text newTextSource;  // ���ο� �ؽ�Ʈ�� �����ϴ� UI ���

    private void Start()
    {
        // ���� ���, ������ ���۵� �� �ؽ�Ʈ�� ����
        UpdateText();
    }

    public void UpdateText()
    {
        string textToDisplay = GetTextFromSource();
        typingEffectScript.SetText(textToDisplay);
    }

    // UI �ؽ�Ʈ�� �ٸ� �ҽ����� �ؽ�Ʈ�� �������� �޼���
    private string GetTextFromSource()
    {
        return newTextSource.text;  // ����: UI �ؽ�Ʈ�� ������ ��ȯ
    }
}