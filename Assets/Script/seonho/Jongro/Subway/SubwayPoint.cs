using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubwayPoint : MonoBehaviour
{
    public string[] sceneNames; // �̵��� ������ �̸�
    public string playerObjectName = "Player";
    public MovingSubway movingSubway; // MovingSubway ��ũ��Ʈ�� ���� ����

    private bool eventTriggered = false;

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
                StartCoroutine(TriggerEvent());
            }
            else
            {
                Debug.Log("Subway is either not stopped or the event has already been triggered.");
            }
        }
    }

    IEnumerator TriggerEvent()
    {
        Player.moveflag = 0;

        yield return new WaitForSeconds(2f); // ���� ������ �ð� ���

        // �������� �� ����
        string selectedScene = sceneNames[Random.Range(0, sceneNames.Length)];
        Debug.Log("Selected scene: " + selectedScene);

        Player.moveflag = 1;

        // �� �̵�
        if (!string.IsNullOrEmpty(selectedScene))
        {
            Debug.Log("Loading scene: " + selectedScene);
            SceneManager.LoadScene(selectedScene);
            Player.playertrans(0, 0);
        }
        else
        {
            Debug.LogError("Selected scene name is invalid.");
        }
    }
}