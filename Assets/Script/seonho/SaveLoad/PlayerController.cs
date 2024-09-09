using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Vector3 startPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /*else
        {
            Destroy(gameObject);
        }*/
    }

    public void SetState(SaveLoadManager.GameState state)
    {
        transform.position = state.playerPosition;
        // �ʿ��� �ٸ� ���� ���� ������ ����
    }
}