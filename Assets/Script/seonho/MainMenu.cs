using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject slotSelectUI;

    void Start()
    {
        // ���� ���� UI ��Ȱ��ȭ
        slotSelectUI.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("newcustomize");
    }

    public void ContinueGame()
    {
        slotSelectUI.SetActive(true);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}