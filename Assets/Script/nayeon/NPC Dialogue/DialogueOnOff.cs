using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnOff : MonoBehaviour
{
    public static DialogueOnOff instance;
    public GameObject ui_Dialogue;
    public float rayDistance = 100f;  // Raycast �Ÿ�
    // public LayerMask hitLayers;  // Ư�� ���̾ ���� Raycast ����
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
     
    void Start()
    {
        ui_Dialogue.SetActive(false);
        
    }


    public void On_uiDialogue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayDistance);
            

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.CompareTag("NPC")) // Ŭ���� ��ü ������Ʈ�� npc�� ��ȭâ ���
                {
                    ui_Dialogue.SetActive(true);
                    StoryManager.instance.StoryStart();
                }
            }

        }
    }
    void Update()
    {
        On_uiDialogue();
    }
}
