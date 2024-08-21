using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubwayPoint : MonoBehaviour
{
    public Transform zoomInPosition; // Ŭ������� ��ġ
    public float zoomInTime = 2f; // Ŭ����� �ð�
    public Animator doorAnimator; // �� �ִϸ��̼�
    public string[] sceneNames; // �̵��� ������ �̸�
    public string playerObjectName = "Player";

    private bool eventTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerObjectName)
        {
            Debug.Log($"Collision detected with {playerObjectName}"); // �浹�� ������Ʈ �̸� �α�
            
            if (!eventTriggered)
            {
                eventTriggered = true; // �̺�Ʈ �߻� �÷��� ����
                StartCoroutine(TriggerEvent());
            }
        }
    }

    IEnumerator TriggerEvent()
    {
        Player.moveflag = 0;
        // �� ���� �ִϸ��̼�
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(2f); // ���� ������ �ð� ���

        // �������� �� ����
        string selectedScene = sceneNames[Random.Range(0, sceneNames.Length)];
        Player.moveflag = 1;
        // �� �̵�
        SceneManager.LoadScene(selectedScene);
    }
}