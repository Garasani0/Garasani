using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{


    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��

    
    Transform AT;
   
    


    void Start()
    {
        Target = GameObject.Find("Player");
        AT = Target.transform;
    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //�÷��̾��� ��ġ�� ����
            transform.position = new Vector3(player.transform.position.x,
                             player.transform.position.y, -10);

            
        }
        else
        {
            Debug.Log("null");
        }
    }
    // Update is called once per frame
    /*void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }*/
    /*void FixedUpdate()
    {

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����

        Vector3 TargetPos = Camera.main.WorldToViewportPoint(Target.transform.position);
        /*TargetPos = new Vector2(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY
           
            );

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }*/
 
    
}


