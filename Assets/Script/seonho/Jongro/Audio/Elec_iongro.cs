using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elec_iongro : MonoBehaviour
{
    public AudioClip clip2; // ���� ����� ����� Ŭ��

    private AudioSource audioSource2;

    void Start()
    {
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // 2�� �Ŀ� ����� Ŭ���� ���
        Invoke("PlayAudioClips", 2f);
    }

    void PlayAudioClips()
    {
        // 2�� ����� Ŭ���� ���� ���
        audioSource2.clip = clip2;
        audioSource2.loop = true;
        audioSource2.Play();
    }
}