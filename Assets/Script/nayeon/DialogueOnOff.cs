using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnOff : MonoBehaviour
{
    public GameObject ui_Dialogue;
    public float rayDistance = 100f;  // Raycast �Ÿ�
    public LayerMask hitLayers;  // Ư�� ���̾ ���� Raycast ����

    void Start()
    {
        ui_Dialogue.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayDistance, hitLayers);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.CompareTag("JM")) // Ŭ���� ��ü ������Ʈ�� �����̸� ��ȭâ ���
                {
                    ui_Dialogue.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }
        }
    }
}
