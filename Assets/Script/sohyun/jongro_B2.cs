using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_B2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        if(npc.onetoB2stair==1)
        {
            GameObject upstair = GameObject.Find("����2�����");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x, upstair.transform.position.y - 6);
            npc.onetoB2stair = 0;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
