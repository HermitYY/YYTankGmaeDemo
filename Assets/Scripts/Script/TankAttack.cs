using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack() {
        if (bulletPrefab != null)
        {
            Bullet bullet = GameObject.Instantiate(bulletPrefab).GetComponent<Bullet>();
            Vector3 position = transform.TransformPoint(Vector3.forward * 3);
            bullet.SetUp(position, 10, transform.eulerAngles);
        }
    }
}
