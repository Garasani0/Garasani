using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class station_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (npc.twoto3stair == 1)
        {
            Debug.Log("�����");
            GameObject upstair = GameObject.Find("3ȣ���°�����");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x + 5, upstair.transform.position.y);
            npc.twoto3stair = 0;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
