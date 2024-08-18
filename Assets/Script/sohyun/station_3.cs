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
            Debug.Log("½ÇÇàµÊ");
            GameObject upstair = GameObject.Find("3È£¼±½Â°­Àå°è´Ü");
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
