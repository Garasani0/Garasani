using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{


    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0f;            // ī�޶��� x��ǥ
    public float offsetY = 0f;           // ī�޶��� y��ǥ
            // ī�޶��� z��ǥ

    public float CameraSpeed = 0.001f;       // ī�޶��� �ӵ�
    Vector3 TargetPos;                      // Ÿ���� ��ġ


    void Start()
    {
        Target = GameObject.Find("Player");
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����

        Vector3 TargetPos = Camera.main.WorldToViewportPoint(Target.transform.position);
        /*TargetPos = new Vector2(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY
           
            );*/

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
 
    
}


