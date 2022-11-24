using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    bool doingQuest = false;

    public float xmove = 0;  // X축 누적 이동량
    public float ymove = 0;  // Y축 누적 이동량
    public float distance = 3;
    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;
    private void Awake()
    {
        transform.position += offset;
    }
    void Update()
    {
        if (!doingQuest)
        {
            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
            ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.
            transform.rotation = Quaternion.Euler(0, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.
            Vector3 reverseDistance = offset; // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
            transform.position = target.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
        }
    }

    public Vector2 GetCursorPosition()
    {
        return Input.mousePosition;
    }

    public void SetCameraFix(bool bValue)
    {
        doingQuest = bValue;
    }
}
