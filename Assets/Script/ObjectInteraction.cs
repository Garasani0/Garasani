using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private RectTransform interactionViewRectTransform;
    public GameObject InteractionView;
    private bool isMouseOver = false; //���� ������Ʈ ���� Ŀ���� �ִ����� ���� �÷���
    public Vector3 mousePosition; //���콺 Ŀ�� ��ǥ
    public Vector3 worldPosition; //���콺 Ŀ�� ������ǥ


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������ �浹 ����");
    }

    private void OnMouseOver() //������ ���� Ŀ�� �ִ� �� ���� 
    {
        if (!isMouseOver) //Ŀ���� ������Ʈ ���� �ö��� �� ���� 1���� ����
        {
            isMouseOver = true;
            string objectName = gameObject.name; //Ŀ�� ������ ������Ʈ �̸� 
            Debug.Log("���콺 ����" + objectName);

            Vector3 mousePosition = Input.mousePosition; //Ŀ�� ��ǥ ������ 
            //worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); //Ŀ����ǥ ������ǥ�� ��ȯ
            worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            ActiveInteraction(); //����â on
        }
        
    }
    void OnMouseExit()
    {
        // ���콺�� ������Ʈ���� ����� �� �÷��׸� ����
        isMouseOver = false;
        InteractionView.SetActive(false);
    }



    public void ActiveInteraction()
    {
        InteractionView.transform.position = (worldPosition); //������Ʈ Ŀ�� ��ġ�� ����â �̵� 
        InteractionView.SetActive(true); //Ŀ�� ���� �� ����â on
    }

    void Start()
    {
        interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        InteractionView.SetActive(false);
    }

    void Update()
    {
        
    }
}
