using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float liveTime = 5;
    private TankBase sourceTank;

    public GameObject destroyEffect;
    public float velocity;
    public Vector3 customGravity; // 自定义的重力加速度

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime < 0)
        {
            MyDestroy();
        }
    }

    private void FixedUpdate()
    {
        if (velocity > 0)
        {
            rb.MovePosition(rb.position + transform.forward * velocity * Time.deltaTime);
        }
        // 自定义重力
        rb.AddForce(customGravity, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        TankBase tank = other.GetComponent<TankBase>();
        if (tank == null  || other == null || other.gameObject == null || sourceTank == null) return;
        if (tank == sourceTank) return;
        if (other.CompareTag("Wall") || (other.tag == sourceTank.tag) || (other.CompareTag("DestructibleWall") && sourceTank.GetComponent<PlayerTank>() == null))
        {
            MyDestroy();
            return;
        }
        tank.Wonnd(sourceTank);
        MyDestroy();
    }

    public void SetUp(Vector3 position, Quaternion angle, TankBase attackTank)
    {
        transform.position = position;
        transform.rotation = angle;
        sourceTank = attackTank;
    }

    private void MyDestroy()
    {
        if (destroyEffect == null) return;
        GameObject effect = Instantiate(destroyEffect, transform.position, transform.rotation);
        GameDataManager.Instance.SetGameObjectEffectAudioSource(effect);
        Destroy(gameObject);
    }
}
