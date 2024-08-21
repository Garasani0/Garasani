using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        // �ʱ� ��� �ð� �� InvokeRepeating ����
        StartCoroutine(StartAfterDelay(initialDelay));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        // ��� �ð� ���� ��ٸ��ϴ�.
        yield return new WaitForSeconds(delay);

        // 1�� �������� ������Ʈ ����
        InvokeRepeating("SpawnMovingObject", 0f, spawnInterval);
    }

    void SpawnMovingObject()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        GameObject obj = Instantiate(movingObjectPrefab, spawnPoint.position, Quaternion.identity);
        Vector3 startPos = obj.transform.position;

        // ������Ʈ�� ���� ����Ʈ���� �̵�
        while (Vector3.Distance(obj.transform.position, stopPoint.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 10�ʰ� ����
        yield return new WaitForSeconds(stopDuration);

        // ������Ʈ�� �ͽ��� ����Ʈ�� �̵� �� ����
        while (Vector3.Distance(obj.transform.position, exitPoint.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(obj);
    }
}