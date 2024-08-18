using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_B1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(npc.oneto2stair==1)
        {
            Debug.Log("실행됨");
            GameObject upstair = GameObject.Find("계단_좌측하단");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x+5, upstair.transform.position.y );
            npc.oneto2stair = 0;
        }
        else if(npc.twoto1stair==1)
        {
            GameObject upstair = GameObject.Find("계단_우측중앙");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x -5, upstair.transform.position.y);
            npc.twoto1stair = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(npc.oneto2stair);
    }
}
