using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train1controller : MonoBehaviour
{
    public static int gotoflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="1ȣ������1"&&gotoflag==2)
        {
            Debug.Log("�����");
            GameObject door1 = GameObject.Find("1ȣ����1");
            Vector2 door1position = new Vector2(door1.transform.position.x, door1.transform.position.y);
            Player.playertrans(door1position.x-3, door1position.y);
            gotoflag = 0; //�̵� �� �ʱ�ȭ


        }
        if (SceneManager.GetActiveScene().name == "1ȣ������2"&&gotoflag==1)
        {
            GameObject door2 = GameObject.Find("1ȣ����2");
            Vector2 door2position = new Vector2(door2.transform.position.x, door2.transform.position.y);
            Player.playertrans(door2position.x+3, door2position.y);
            gotoflag = 0;  //�̵� �� �ʱ�ȭ
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            if (gameObject.name == "1ȣ����1")
            {
                gotoflag = 1; //����1���� ����2�� �� ��
                SceneManager.LoadScene("1ȣ������2");

            }
            if (gameObject.name == "1ȣ����2")
            {
                gotoflag = 2; //����2���� ����1�� �� ��
                SceneManager.LoadScene("1ȣ������1");

            }
        }
       



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
