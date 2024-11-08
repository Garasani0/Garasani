using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TreeEditor.TreeGroup;
using UnityEngine.SceneManagement;

public class itemManager : MonoBehaviour
{
    public Dialogue[] contextList;
    public GameObject redLight;

    int itemFlag = 0;
    public GameObject item;

    AudioSource zipper; //효과음

    void Start()
    {
        zipper = GameObject.Find("zipper").GetComponent<AudioSource>(); //효과음
    }

    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log("아이템: " + gameObject.name);
        Debug.Log(intertest.colitemname);

        
        if (itemFlag == 0 && intertest.colitemname == "item_비상조명등")
        {
            redLight.SetActive(false);
            StartCoroutine(AutoEvent());


        }


    }

    private IEnumerator AutoEvent()
    {
        zipper.Play();
        DialogueManager.instance.ui_dialogue.SetActive(true);

        contextList = DataManager.instance.GetDialogue(5, 5);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

        //inventory.AddItem("비상조명등");

        item.SetActive(false); 
        itemFlag = 1;
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }
}
