using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class station3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(npc.B2to3==1)
        {
            GameObject upstair = GameObject.Find("3ȣ���°�����");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x +5, upstair.transform.position.y+3);
            npc.B2to3 = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
