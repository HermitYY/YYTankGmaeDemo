using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    [Header("跟随目标设置")]
    [Tooltip("需要跟随的物体，比如玩家或坦克")]
    public Transform target;

    [Header("小地图视角设置")]
    [Tooltip("摄像机离目标的垂直高度")]
    public float height = 30f;

    [Tooltip("是否让小地图摄像机跟随目标旋转")]
    public bool rotateWithTarget = true;

    [Tooltip("是否平滑过渡")]
    public bool smoothFollow = true;

    [Tooltip("平滑插值速度（越大越快）")]
    public float followSmoothSpeed = 5f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + Vector3.up * height;

        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = desiredPosition;
        }

        if (rotateWithTarget)
        {
            // 摄像机保持俯视，但Y轴旋转与目标一致
            Quaternion targetRotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, followSmoothSpeed * Time.deltaTime);
        }
        else
        {
            // 固定朝北（Y=0）
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
