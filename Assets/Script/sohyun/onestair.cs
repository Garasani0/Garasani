using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onestair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
            GameObject upstair = GameObject.Find("1호선승강장계단");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x+5, upstair.transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
