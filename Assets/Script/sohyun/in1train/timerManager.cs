using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class timerManager : MonoBehaviour
{
    public static timerManager Instance { get; private set; }

    public float timeRemaining = 300f; // Ÿ�̸� �ʱ�ȭ (5��)
    private bool isTimerRunning = false;

    void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ������Ʈ�� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ı�
        }
    }

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                isTimerRunning = false;
                timeRemaining = 0;
                OnTimerEnd(); // Ÿ�̸� ���� �� ȣ��
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    private void OnTimerEnd()
    {
        // Ÿ�̸� ���� �� ���ϴ� �ൿ�� ���⿡ �߰�

        SceneManager.LoadScene("1ȣ������"); // ���� �� ���� ������ ��ȯ
        Player.playertrans(3.34f, 0.003f);
    }
}