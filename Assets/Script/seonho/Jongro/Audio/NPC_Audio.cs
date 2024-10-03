using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Audio : MonoBehaviour
{
    public AudioClip backgroundMusicClip;  // ��� ���� ����� Ŭ��
    public AudioClip dialogueMusicClip;    // ��ȭ ���� ����� Ŭ��
    public float fadeDuration = 1f;        // ���̵���/���̵�ƿ��� �ɸ��� �ð�
    public string targetNPCName = "NPC";  // ��ȭ ���� ��ȯ�� �� NPC �̸�

    private AudioSource audioSource;        // �������� ������ AudioSource
    private bool isDialoguePlaying = false; // ��ȭ ���� ��� ���� üũ

    void Start()
    {
        // ���ο� AudioSource�� �������� ����
        audioSource = gameObject.AddComponent<AudioSource>();

        // ������� ���� �� ���
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true; // ��������� ������ ����
        audioSource.Play();

        GameObject upstair = GameObject.Find("���_�����߾�"); 
        Player.playertrans(upstair.transform.position.x - 7, upstair.transform.position.y);
    }

    void Update()
    {
        if (DialogueManager.instance != null)
        {
            string currentNPCName = DialogueManager.instance.name.text;
            //Debug.Log($"Current NPC Name: {currentNPCName}");

            if (currentNPCName == targetNPCName)
            {
                if (!isDialoguePlaying)
                {
                    StartCoroutine(SwitchToDialogueMusic());
                }
            }
            else
            {
                if (isDialoguePlaying)
                {
                    StartCoroutine(SwitchToBackgroundMusic());
                }
            }
        }
        else
        {
            Debug.LogWarning("DialogueManager.instance is null.");
        }
    }


    private IEnumerator SwitchToDialogueMusic()
    {
        Debug.Log("Switching to dialogue music...");
        isDialoguePlaying = true;

        // ��� ���� ���̵�ƿ�
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

        // ��ȭ �������� ��ȯ �� ���̵���
        audioSource.clip = dialogueMusicClip;
        audioSource.loop = true; // ��ȭ ������ ������ ����
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }
    }


    private IEnumerator SwitchToBackgroundMusic()
    {
        Debug.Log("Switching to background music...");
        // ��ȭ ���� ���̵�ƿ�
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

        // ��� �������� ��ȯ �� ���̵���
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true; // ��� ������ ������ ����
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        isDialoguePlaying = false;
    }
}