using UnityEngine;
using TMPro;

public class FlashlightController : MonoBehaviour
{
    //비상조명등의 불빛이 플레이어의 회전에 따라 함께 회전하도록 하는 코드.
    private Transform playePosition;
    private Vector2 direction;
    private Quaternion rotation;
    public playerparents playerparents;
    public InventoryManager inventoryManager;
    public TMP_Text equippedItemName;
    public SpriteMask flashlightSpriteMask;

    private void Start()
    {
        flashlightSpriteMask.enabled = false;
        playePosition = FindObjectOfType<Transform>();
    }
    void Update()
    {
        if (equippedItemName.text == "비상조명등")
        {
            if (!flashlightSpriteMask.enabled)
            {
                flashlightSpriteMask.enabled = true; // 스프라이트 마스크 활성화
            }

            this.transform.position = playerparents.GetCurrentPosition();

            direction = playerparents.GetMovementDirection();

            //방향 확인
            //Debug.Log("Direction: " + direction);


            // 방향에 맞는 회전 적용
            if (direction.x == 1f) // 오른쪽
            {
                rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (direction.x == -1f) // 왼쪽
            {
                rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (direction.y == 1f) // 위쪽
            {
                rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (direction.y == -1f) // 아래쪽
            {
                rotation = Quaternion.Euler(0, 0, 0);
            }

            this.transform.rotation = rotation;
        }
        else
        {
            if (flashlightSpriteMask.enabled)
            {
                flashlightSpriteMask.enabled = false; // 스프라이트 마스크 비활성화
            }

        }
    }
}
