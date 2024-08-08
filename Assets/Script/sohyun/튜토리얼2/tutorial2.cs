using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;

public class tutorial2 : MonoBehaviour
{
    public GameObject ��ǳ��;
    private IEnumerator �����Ÿ�;
    public GameObject ��ư;
    public GameObject dark;
    public TMP_Text ����;
    public TMP_Text �̸�;
    public static int textflag = 0;
    public GameObject door;
    public static int doorflag = 0;

    [SerializeField] private GameObject targetAnimatorObject;
    public float moveSpeed = 5f;
    public string boolParameterName = "Left";
    private Animator NPCAnimator;

    string[] text = new string[4] {  "...?", "...�̰� ���� �Ҹ���...?", "���ʿ��� ���� �ٰ����� �־�...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        if (targetAnimatorObject != null)
        {
            NPCAnimator = targetAnimatorObject.GetComponent<Animator>();
            NPCAnimator.SetBool(boolParameterName, false);
        }
        else
        {
            Debug.LogError("Target animator object not assigned.");
        }

        Vector3 newposition = door.transform.position;
        Player.playertrans(newposition.x+3, newposition.y);
        ��ǳ��.SetActive(false);
        �̸�.text = customize.playername;
        ����.text = text[textflag];
        Invoke("dontmove", 1f);
        �����Ÿ� = ����();
    }
    private IEnumerator ����()
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(�����Ÿ�);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "�������̹�")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
                    textflag++;

                    //SceneManager.LoadScene("Dialogue");
                }
            }
        }
    }
    
    public void doordown()
    {
        Debug.Log("Ŭ����");
        if (doorflag==0)
        {
            
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
            textflag++;
            doorflag++;
        }
    }
   
    public void button()
    {
        if (textflag == 0)
        {
            textflag++;
        }
        else if (textflag <= 1)
        {
            �̸�.text = customize.playername;
            ����.text = text[textflag];
            textflag++;

        }
        else if (textflag == 2)
        {
            �̸�.text = customize.playername;
            ����.text = text[textflag];
            //customize.moveflag = 1;
            //��ǳ��.SetActive(false);
            textflag++;
        }
        else if (textflag == 3 && doorflag ==0)
        {
            ��ǳ��.SetActive(false);
        }
        else if (textflag==4 && doorflag==1)
        {

            Debug.Log("������");
            
            ��ǳ��.SetActive(true);
            �̸�.text = customize.playername;
            ����.text = text[3];
            textflag++;
        }

        else if (textflag > 4)
        {
            ��ǳ��.SetActive(false);
            StartCoroutine(NPCEventCoroutine());
            //SceneManager.LoadScene("Prologue2");

        }
    }

    IEnumerator NPCEventCoroutine()
    {
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        float targetXPosition = -6.0f; // ��ǥ X ��ǥ
        float moveDuration = 2.0f; // �̵��� �ð�

        Vector3 startPosition = targetAnimatorObject.transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, startPosition.y, startPosition.z);
        float elapsedTime = 0f;

        Debug.Log($"Starting NPC movement from {startPosition} to {targetPosition}");

        while (elapsedTime < moveDuration)
        {
            targetAnimatorObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            Debug.Log($"NPC position: {targetAnimatorObject.transform.position}");
            yield return null;
        }

        targetAnimatorObject.transform.position = targetPosition; // Ensure it ends at the exact position

        Debug.Log($"NPC movement ended at {targetAnimatorObject.transform.position}");

        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, false);
        }
    }

    void dontmove()
    {
        customize.moveflag = 0;
        ��ǳ��.SetActive(true);

    }
}
