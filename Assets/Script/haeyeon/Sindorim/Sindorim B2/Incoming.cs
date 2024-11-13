using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    public GameObject npcPrefab;       // NPC ������
    public Transform targetPosition;   // NPC�� ���� ��ǥ ��ġ
    public float spawnInterval = 2f;   // NPC ���� ����
    public float moveSpeed = 3f;       // NPC �̵� �ӵ�
    public int maxNPCCount = 10;       // �ִ� ���� NPC ��

    private List<GameObject> npcList = new List<GameObject>();  // ������ NPC ����Ʈ
    private bool dialogueTriggered = false; // ��ȭ�� Ʈ���� �Ǿ����� Ȯ��
    public Dialogue[] contextList;
    int dialogueID = 12; //dialogue ���� ���̵�

    void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    IEnumerator SpawnNPCs()
    {
        while (npcList.Count < maxNPCCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            // NPC ����
            GameObject npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            npc.tag = "NPC";  // NPC �±� ����
            npcList.Add(npc);
        }
    }

    void Update()
    {
        // �� NPC�� ��ǥ ��ġ�� �̵���Ű��
        foreach (GameObject npc in npcList)
        {
            if (npc != null && Vector3.Distance(npc.transform.position, targetPosition.position) > 0.1f)
            {
                npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            }
        }

        // NPC ���� �ִ� ���� �������� �� ��ȭ ����
        if (npcList.Count == maxNPCCount && !dialogueTriggered)
        {
            DataManager.instance.csv_FileName = "SindorimB1B2";
            DataManager.instance.DialogueLoad();
            Debug.Log("SindorimB1B2 CSV ���� �ҷ����� �Ϸ�");

            StartCoroutine(StartDialogue()); // ID=12 ��ȭ ����
            dialogueTriggered = true; // ��ȭ�� ���۵Ǿ����� ǥ��
        }
    }

    private IEnumerator StartDialogue()
    {
        // ��ȭ UI Ȱ��ȭ
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // ������ ID�� ��ȭ ���� �ҷ����� �� ó��
        Dialogue[] contextList = DataManager.instance.GetDialogue(12, 12);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        // ��ȭ�� ������ UI ��Ȱ��ȭ
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}