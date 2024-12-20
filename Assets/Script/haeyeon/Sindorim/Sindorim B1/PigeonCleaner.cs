using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonCleaner : MonoBehaviour
{
    // 정리 로직만 포함
    public static void CleanUp(GameObject pigeon)
    {
        if (pigeon != null)
        {
            GameObject.Destroy(pigeon);  // 삭제 호출을 UnityEngine 네임스페이스로 지정
        }
    }
}