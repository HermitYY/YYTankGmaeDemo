using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject Turret;
    public GameObject Barrel;

    private int turretRotaleDuration = 1;
    private int turretRotaleDirection = 1;
    private float turretRotaleCurDuration = 0;

    void Start()
    {
        Turret.transform.Rotate(Vector3.up, -15);
    }

    // Update is called once per frame
    void Update()
    {
        // ��չ̨����ת
        transform.RotateAround(Vector3.zero, Vector3.up, 3 * Time.deltaTime);
        // ��̨�Լ�����ת
        if (turretRotaleCurDuration < turretRotaleDuration)
        {
            turretRotaleCurDuration += Time.deltaTime;
        } else
        {
            turretRotaleCurDuration = 0;
            turretRotaleDirection *= -1;
        }
        // �ڹ�����ת
        Turret.transform.Rotate(Vector3.up, 30 * Time.deltaTime * turretRotaleDirection);
        Barrel.transform.RotateAround(Turret.transform.position ,Vector3.right, 5 * Time.deltaTime * turretRotaleDirection);
    }
}
