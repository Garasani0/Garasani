using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletone : MonoBehaviour
{
    private static singletone instance;

    void Awake()
    {
        // �̹� �ν��Ͻ��� �����ϴ��� Ȯ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // �� ������Ʈ�� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);  // �ߺ� ������ ��� �ı�
        }
    }
}
