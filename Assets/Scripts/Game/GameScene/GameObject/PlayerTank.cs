using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTank : TankBase
{
    private Rigidbody rb;
    public GameObject waeponSolt;

    protected override void Start()
    {
        base.Start();
        GamePanel.Instance.GetComponent<HealthBar>().UpdateHealthUI(maxHealth, currentHealth);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Fire()
    {
        TankWeapon weapon = GetComponentInChildren<TankWeapon>();
        if (weapon == null) return;
        weapon.Shoot();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Move()
    {

        //transform.Translate(Input.GetAxis("Vertical") * transform.forward * moveSpeed * Time.deltaTime, Space.World);
        rb.MovePosition(rb.position + transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(Input.GetAxis("Horizontal") * transform.up * moveRotaAngularVelocity * Time.deltaTime, Space.World);

        if (turret != null && Input.GetMouseButton(1))
        {
            turret.transform.Rotate(transform.up * Input.GetAxis("Mouse X") * turretRotaAngularVelocity * Time.deltaTime, Space.World);
        }
    }

    public override void Wonnd(TankBase attackTank)
    {
        base.Wonnd(attackTank);
        GamePanel.Instance.GetComponent<HealthBar>().UpdateHealthUI(maxHealth, currentHealth);
        Debug.Log(" ‹µΩ…À∫¶");
    }

    public void ChangeWeapon(GameObject weaponPrefab)
    {
        for (int i = 0; i < waeponSolt.transform.childCount; i++)
        {
            Transform child = waeponSolt.transform.GetChild(i);
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }
        Instantiate(weaponPrefab, waeponSolt.transform);
    }
}
