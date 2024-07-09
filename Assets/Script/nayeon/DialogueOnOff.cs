using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnOff : MonoBehaviour
{
    public GameObject ui_Dialogue;


    void Start()
    {
        ui_Dialogue.SetActive(false);
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is not found! Make sure your camera has the 'MainCamera' tag.");
            return;
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.CompareTag("JM")) //Ŭ���� ��ü ������Ʈ�� �����̸� ��ȭâ ���
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
