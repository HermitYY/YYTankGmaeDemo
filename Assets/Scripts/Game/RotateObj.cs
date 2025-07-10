using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [Header("旋转目标物体")]
    public Transform target;

    [Header("旋转范围（0~1，代表360度比例）")]
    [Range(0f, 1f)]
    public float range01 = 0f;

    [Range(0f, 1f)]
    public float range02 = 1f;

    [Header("旋转速度（度/秒）")]
    public float rotationSpeed = 30f;

    private float angleFrom;
    private float angleTo;
    private float currentAngle;
    private int direction = 1;
    void Start()
    {
        InitAngles();
        currentAngle = angleFrom;
    }

    void Update()
    {
        if (target == null) return;

        if (Mathf.Approximately(angleFrom, angleTo))
        {
            // 连续旋转模式
            target.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // 循环往返旋转模式
            currentAngle += direction * rotationSpeed * Time.deltaTime;

            if ((direction > 0 && currentAngle >= angleTo) || (direction < 0 && currentAngle <= angleFrom))
            {
                currentAngle = Mathf.Clamp(currentAngle, angleFrom, angleTo);
                direction *= -1;
            }

            Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
            target.rotation = rotation;
        }
    }

    void OnValidate()
    {
        InitAngles();
    }

    private void InitAngles()
    {
        float a = range01 * 360f;
        float b = range02 * 360f;
        angleFrom = Mathf.Min(a, b);
        angleTo = Mathf.Max(a, b);
    }
}
