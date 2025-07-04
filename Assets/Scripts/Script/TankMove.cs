using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float xMouseInput = Input.GetAxis("Mouse X");
        float yMouseMidInput = Input.GetAxis("Mouse ScrollWheel");
        float yMouseMidInput2 = Input.mouseScrollDelta.y;


        // ��ת
        transform.Rotate(transform.up, 30 * xInput * Time.deltaTime, Space.World);
        // ǰ��
        transform.Translate(transform.forward * 5 * yInput * Time.deltaTime, Space.World);

        // ��̨��ת
        Transform turret = transform.Find("Turret");
        if (turret != null && Input.GetMouseButton(2))
        {
            turret.Rotate(transform.up, 100 * xMouseInput * Time.deltaTime, Space.World);
        }

        // �ڹ���ת
        if (turret != null )
        {
            Transform barrel = turret.Find("Barrel");
            if (barrel != null)
            {
                barrel.RotateAround(turret.transform.position, turret.transform.right, 200 * yMouseMidInput2 * Time.deltaTime * -1);
            }
        }
    }
}
