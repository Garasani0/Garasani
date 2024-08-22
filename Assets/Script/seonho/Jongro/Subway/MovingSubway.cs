using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingSubway : MonoBehaviour
{
    public GameObject movingObjectPrefab; // �̵��ϴ� ������Ʈ ������
    public Transform spawnPoint; // ������Ʈ�� ������ ��ġ
    public Transform stopPoint; // ������Ʈ�� ���� ��ġ
    public Transform exitPoint; // ������Ʈ�� ����� ��ġ
    public float moveSpeed = 2f; // ������Ʈ �̵� �ӵ�
    public float spawnInterval = 60f; // ������Ʈ ���� ���� (1��)
    public float stopDuration = 10f; // ������Ʈ�� �����ִ� �ð�
    public float initialDelay = 5f; // �ʱ� ��� �ð� (30��)

    public bool IsSubwayStopped { get; private set; } = false;
    private GameObject currentSubway;

    private void Start()
    {
        StartCoroutine(StartAfterDelay(initialDelay));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        InvokeRepeating("SpawnMovingObject", 0f, spawnInterval);
    }

    void SpawnMovingObject()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        IsSubwayStopped = false;
        currentSubway = Instantiate(movingObjectPrefab, spawnPoint.position, Quaternion.identity);

        // ������Ʈ�� ���� ����Ʈ���� �̵�
        while (Vector3.Distance(currentSubway.transform.position, stopPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ����ö�� ���� ����Ʈ�� �������� �� ���� ������Ʈ
        IsSubwayStopped = true;
        Debug.Log("Subway has reached the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 10�ʰ� ����
        yield return new WaitForSeconds(stopDuration);

        IsSubwayStopped = false;
        Debug.Log("Subway is leaving the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // ������Ʈ�� �ͽ��� ����Ʈ�� �̵� �� ����
        while (Vector3.Distance(currentSubway.transform.position, exitPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(currentSubway);
    }
}