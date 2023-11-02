using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    #region Variables

    public float distance;
    public float height;
    public float angle;
    public float lookAtHeight;
    public Transform target;
    public float smoothTime;
    #endregion Variables

    private void LateUpdate()
    { 
        HandleCamera();
    }

    public void HandleCamera()
    {
        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);  // Vector3(0, height, -distance), 
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;    // up 방향으로 60도 회전 후 WorldPosition을 곱함
        Vector3 targetPos = target.position;
        targetPos.y += lookAtHeight;    // 상단쪽에 위치하기 위함.

        Vector3 finalPosition = targetPos + rotatedVector;  // 회전된 벡터를 타겟의 위치에 더함
        
        
        transform.position = Vector3.Lerp(transform.position, finalPosition, smoothTime);
        transform.LookAt(target.position);

    }
}
