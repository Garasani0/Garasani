using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro�� ����ϱ� ���� �߰�
using System.Collections;

public class DoubleClickToggleButton : MonoBehaviour
{
    public Button button; // ��ư ������Ʈ
    public Image buttonImage; // ��ư�� �̹��� ������Ʈ
    public Sprite newSprite; // ��ü�� ���ο� �̹��� ��������Ʈ
    private Sprite originalSprite; // ���� �̹��� ��������Ʈ
    private int clickCount = 0; // Ŭ�� Ƚ��
    private float clickTime = 0; // Ŭ�� �ð�
    private float clickDelay = 0.5f; // ���� Ŭ�� ���� �ð� ����
    private bool isOriginal = true; // ���� �̹����� ���� �̹������� ����

    public TextMeshProUGUI itemNameText; // ������ �̸��� ǥ���� TextMeshProUGUI
    public TextMeshProUGUI itemInfoText; // ������ ������ ǥ���� TextMeshProUGUI
    public TextMeshProUGUI itemName; // ������ �̸�
    public TextMeshProUGUI itemInfo; // ������ ����
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        originalSprite = buttonImage.sprite; // ���� �̹��� ����
    }

    void OnButtonClick()
    {
        clickCount++;
        if (clickCount == 1)
        {
            clickTime = Time.time;
        }
        else if (clickCount == 2 && Time.time - clickTime < clickDelay)
        {
            if (isOriginal)
            {
                buttonImage.sprite = newSprite; // ���ο� �̹����� ����
                Debug.Log("��ư�� ���õǾ����ϴ�.");
            }
            else
            {
                buttonImage.sprite = originalSprite; // ���� �̹����� ����
                Debug.Log("��ư�� ���� �̹����� ���ư����ϴ�.");
            }
            isOriginal = !isOriginal; // �̹��� ���� ���
            clickCount = 0;

            // ������ �̸��� ���� ������Ʈ
            UpdateItemInfo();
        }
        else
        {
            clickCount = 0;
        }
    }

    void Update()
    {
        if (clickCount == 1 && Time.time - clickTime >= clickDelay)
        {
            clickCount = 0; // ���� Ŭ�� ������ ������ Ŭ�� Ƚ�� �ʱ�ȭ
        }
    }

    void UpdateItemInfo()
    {
        itemNameText.text = itemName.text;
        itemInfoText.text = itemInfo.text;
        Debug.Log($"������ �̸�: {itemName}, ������ ����: {itemInfo}");
    }
}
