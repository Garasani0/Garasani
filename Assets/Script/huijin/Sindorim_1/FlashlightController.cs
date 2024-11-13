using UnityEngine;
using TMPro;

public class FlashlightController : MonoBehaviour
{
    //���������� �Һ��� �÷��̾��� ȸ���� ���� �Բ� ȸ���ϵ��� �ϴ� �ڵ�.
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
        if (equippedItemName.text == "��������")
        {
            if (!flashlightSpriteMask.enabled)
            {
                flashlightSpriteMask.enabled = true; // ��������Ʈ ����ũ Ȱ��ȭ
            }

            this.transform.position = playerparents.GetCurrentPosition();

            direction = playerparents.GetMovementDirection();

            //���� Ȯ��
            //Debug.Log("Direction: " + direction);


            // ���⿡ �´� ȸ�� ����
            if (direction.x == 1f) // ������
            {
                rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (direction.x == -1f) // ����
            {
                rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (direction.y == 1f) // ����
            {
                rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (direction.y == -1f) // �Ʒ���
            {
                rotation = Quaternion.Euler(0, 0, 0);
            }

            this.transform.rotation = rotation;
        }
        else
        {
            if (flashlightSpriteMask.enabled)
            {
                flashlightSpriteMask.enabled = false; // ��������Ʈ ����ũ ��Ȱ��ȭ
            }

        }
    }
}
