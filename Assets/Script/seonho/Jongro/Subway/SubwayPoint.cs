using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubwayPoint : MonoBehaviour
{
    public string playerObjectName = "Player";
    public MovingSubway movingSubway; // MovingSubway ��ũ��Ʈ�� ���� ����

    private bool eventTriggered = false;
    private string sceneToLoad;

    private void Start()
    {
        if (movingSubway == null)
        {
            // MovingSubway ��ũ��Ʈ�� ������ ã�� �Ҵ�
            movingSubway = FindObjectOfType<MovingSubway>();
            if (movingSubway == null)
            {
                Debug.LogError("MovingSubway reference is not assigned and no MovingSubway object found in the scene.");
            }
        }

        if (movingSubway != null)
        {
            movingSubway.OnAudioClipPlayed += HandleAudioClipPlayed;
        }
    }

    private void OnDestroy()
    {
        if (movingSubway != null)
        {
            movingSubway.OnAudioClipPlayed -= HandleAudioClipPlayed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerObjectName)
        {
            Debug.Log($"Collision detected with {playerObjectName}");

            // ���� ����ö ���¿� �̺�Ʈ Ʈ���� ���¸� �α׷� ���
            Debug.Log($"IsSubwayStopped: {movingSubway?.IsSubwayStopped}, EventTriggered: {eventTriggered}");

            // ����ö�� stopPoint�� �����߰� �̺�Ʈ�� ���� �߻����� �ʾ�����
            if (movingSubway != null && movingSubway.IsSubwayStopped && !eventTriggered)
            {
                Debug.Log("Subway is stopped and event is not triggered yet. Triggering event.");
                eventTriggered = true; // �̺�Ʈ �߻� �÷��� ����
                StartCoroutine(WaitBeforeProcessing());
            }
            else
            {
                Debug.Log("Subway is either not stopped or the event has already been triggered.");
            }
        }
    }

    IEnumerator WaitBeforeProcessing()
    {
        yield return new WaitForSeconds(2f); // ���� ������ �ð� ���
        SceneManager.LoadScene(sceneToLoad);
    }


    private void HandleAudioClipPlayed(AudioClip clip)
    {
        if (clip == movingSubway.scene1Clip1 || clip == movingSubway.scene1Clip2)
        {
            sceneToLoad = movingSubway.scene1Name;
        }
        else
        {
            sceneToLoad = movingSubway.scene2Name;
        }
    }
}