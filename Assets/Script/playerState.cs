using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    /*player 상태 관리 스크립트
    변수로 상태 추가 */

    public static playerState instance;
    public bool isTired; //피로이상 상태 

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTired = true;
    }

    // Update is called once per frame
    void Update()
    {
        Player.moveflag = 1;
        customize.sceneflag = 3;
    }
}
