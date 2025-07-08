using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTank : TankBase
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    protected override void Fire()
    {
    }

    private void Move()
    {

        transform.Translate(Input.GetAxis("Vertical") * transform.forward * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Input.GetAxis("Horizontal") * transform.up * moveRotaAngularVelocity * Time.deltaTime, Space.World);

        if (turret != null && Input.GetMouseButton(1))
        {
            turret.transform.Rotate(transform.up * Input.GetAxis("Mouse X") * turretRotaAngularVelocity * Time.deltaTime, Space.World);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    protected override void Wonnd(TankBase attackTank)
    {
        base.Wonnd(attackTank);
        GamePanel.Instance.UpdateHealthUI(maxHealth, currentHealth);
    }
}
