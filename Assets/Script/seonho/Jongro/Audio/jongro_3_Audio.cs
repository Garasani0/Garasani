using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_3_Audio : MonoBehaviour
{
    public AudioClip audioClip; // ������ ����� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ�

    void Start()
    {
        // ����� �ҽ��� �߰��ϰ� ����
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // ���� ��� ����
        audioSource.Play(); // ����� ��� ����    
    }
}