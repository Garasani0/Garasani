using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ExcludeAreaClickHandler : MonoBehaviour
{
    public List<RectTransform> excludeAreas; // ������ ���� ����Ʈ
    public GraphicRaycaster raycaster; // ĵ������ �ִ� GraphicRaycaster
    public GameObject LightSet; // ��Ȱ��ȭ�� GameObject

    void Update()
    {
        if (LightSet != null && LightSet.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverExcludedArea())
            {
                Debug.Log("Clicked outside excluded areas");
                LightSet.SetActive(false); // LightSet ��Ȱ��ȭ
            }
        }
    }

    bool IsPointerOverExcludedArea()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, raycastResults);

        foreach (var result in raycastResults)
        {
            if (excludeAreas.Contains(result.gameObject.GetComponent<RectTransform>()))
            {
                Debug.Log("Slider inside");
                return true;
            }
        }

        return false;
    }
}

