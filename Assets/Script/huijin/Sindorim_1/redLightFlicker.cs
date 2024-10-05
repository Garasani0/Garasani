using System.Collections;
using UnityEngine;

public class RedLightFlicker : MonoBehaviour
{
    public Dialogue[] contextList;
    int dialogueID = 3; //dialogue ���� ���̵�

    public SpriteRenderer spriteRenderer;  // ��������Ʈ ������
    public float minAlpha = 0.0f;  // �ּ� ����
    public float maxAlpha = 0.8f;  // �ִ� ����
    public float flickerSpeed = 1.0f;  // �����̴� �ӵ�

    private float targetAlpha;  // ��ǥ ���� ��
    private float alphaChangeRate;  // ���� �� ��ȭ ����

    void Start()
    {
        //csv���� �ε� //���� �ּ�ó�� ����
        DataManager.instance.csv_FileName = "Sindorim_1";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        //�ʱ� ��ǥ ���� �� ����
        targetAlpha = maxAlpha;
        alphaChangeRate = flickerSpeed * Time.deltaTime;  //���� ��ȭ ���� �ʱ�ȭ
    }

    void Update()
    {
        // ���� �� ����
        Color color = spriteRenderer.color;
        color.a = Mathf.MoveTowards(color.a, targetAlpha, alphaChangeRate);
        spriteRenderer.color = color;

        // ���� ���� ��ǥ���� �����ߴ��� Ȯ��
        if (Mathf.Approximately(color.a, targetAlpha))
        {
            // ��ǥ ���� ���� ��ȯ
            targetAlpha = (targetAlpha == maxAlpha) ? minAlpha : maxAlpha;
        }
    }

    //�浹�� �ڵ����� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(AutoEvent());
            //�̺�Ʈ�� �� ���� �Ͼ
            GetComponent<Collider2D>().enabled = false;

        }
    }

    private IEnumerator AutoEvent()
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(3, 4);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
