using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour
{
    public GameObject npcPrefab;       // NPC 프리팹
    public Transform targetPosition;   // NPC가 모일 목표 위치
    public float spawnInterval = 2f;   // NPC 생성 간격
    public float moveSpeed = 3f;       // NPC 이동 속도
    public int maxNPCCount = 10;       // 최대 생성 NPC 수

    private List<GameObject> npcList = new List<GameObject>();  // 생성된 NPC 리스트
    private bool dialogueTriggered = false; // 대화가 트리거 되었는지 확인
    public Dialogue[] contextList;
    int dialogueID = 12; //dialogue 시작 아이디

    void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    IEnumerator SpawnNPCs()
    {
        while (npcList.Count < maxNPCCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            // NPC 생성
            GameObject npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            npc.tag = "NPC";  // NPC 태그 지정
            npcList.Add(npc);
        }
    }

    void Update()
    {
        // 각 NPC를 목표 위치로 이동시키기
        foreach (GameObject npc in npcList)
        {
            if (npc != null && Vector3.Distance(npc.transform.position, targetPosition.position) > 0.1f)
            {
                npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            }
        }

        // NPC 수가 최대 수에 도달했을 때 대화 시작
        if (npcList.Count == maxNPCCount && !dialogueTriggered)
        {
            DataManager.instance.csv_FileName = "SindorimB1B2";
            DataManager.instance.DialogueLoad();
            Debug.Log("SindorimB1B2 CSV 파일 불러오기 완료");

            StartCoroutine(StartDialogue()); // ID=12 대화 시작
            dialogueTriggered = true; // 대화가 시작되었음을 표시
        }
    }

    private IEnumerator StartDialogue()
    {
        // 대화 UI 활성화
        DialogueManager.instance.ui_dialogue.SetActive(true);

        // 지정된 ID의 대화 내용 불러오기 및 처리
        Dialogue[] contextList = DataManager.instance.GetDialogue(12, 12);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        // 대화가 끝나면 UI 비활성화
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}