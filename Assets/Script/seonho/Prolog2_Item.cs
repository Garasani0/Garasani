using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog2_Item : MonoBehaviour
{
    public TMP_Text ����;
    public TMP_Text �̸�;
    public GameObject ��ǳ��;
    public GameObject hammer;
    public GameObject hammerInfo;

    int hammerflag = 0;

    public Inventory inventory; // Inventory ��ũ��Ʈ ����

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.�浹�����۸�);
        Debug.Log("Hammer flag: " + hammerflag);

        if (intertest.�浹�����۸� == "���")
        {
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "â���� ���� ������ ������.";
            Debug.Log("Loading scene Chungmuro_B3");
            SceneManager.LoadScene("Chungmuro_B3");
        }

        else if (intertest.�浹�����۸� == "����ġ")
        {
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "[����ġ] : �̰ɷ� â���� ���� ���� �� ���� �� ����.";
            hammer.SetActive(false);
            hammerInfo.SetActive(false);
            inventory.AddItem("����ġ", "�̰ɷ� â���� ���� ���� �� ���� �� ����.");
            hammerflag = 1;
            Debug.Log("Hammer collected, hammerflag set to 1");
        }
    }
}