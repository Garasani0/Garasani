using UnityEngine;

public class playerparents : MonoBehaviour
{
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal"); 
        float dirY = Input.GetAxisRaw("Vertical");
        direction.Set(dirX, dirY);

        GameObject basebody = GameObject.Find("basebody");

        // ���� ��ü�� basebody�� �θ����� Ȯ��
        if (basebody.transform.parent == transform)
        {
            // basebody�� x, y ��ǥ�� Vector2�� ����
            Vector2 position = new Vector2(basebody.transform.position.x, basebody.transform.position.y);

            // z ���� 0���� �Ͽ� Vector3�� ��ȯ
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }


    }

    //���� ���� ���
    public Vector2 GetMovementDirection()
    {
        return direction;
    }
    public Vector3 GetCurrentPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
