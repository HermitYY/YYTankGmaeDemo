using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float liveTime = 5;
    private float velocity;
    void Start()
    {

    }

    void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime < 0)
        {
            Destroy(this.gameObject);
        }
        if (velocity > 0)
        {
            transform.Translate(transform.forward * Time.deltaTime * velocity, Space.World);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        TankAttack tank = other.GetComponent<TankAttack>();
        if (tank == null)
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }

    public void SetUp(Vector3 position, float _velocity, Vector3 eulerAngles)
    {
        transform.position = position;
        transform.eulerAngles = eulerAngles;
        velocity = _velocity;
    }
}
