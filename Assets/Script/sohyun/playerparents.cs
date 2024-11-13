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

        // 현재 객체가 basebody의 부모인지 확인
        if (basebody.transform.parent == transform)
        {
            // basebody의 x, y 좌표를 Vector2로 저장
            Vector2 position = new Vector2(basebody.transform.position.x, basebody.transform.position.y);

            // z 값을 0으로 하여 Vector3로 변환
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }


    }

    //방향 벡터 사용
    public Vector2 GetMovementDirection()
    {
        return direction;
    }
    public Vector3 GetCurrentPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
