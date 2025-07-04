using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorqueFnTest : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.maxAngularVelocity = 100f;
        //rb.AddTorque(transform.up * 10);
        //rb.AddRelativeTorque(Vector3.up * 10);
        //transform.Rotate(transform.up * 10);

        //rb.AddForce(transform.forward * 10);

        //rb.AddExplosionForce(100, transform.position, 10, -1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.angularVelocity);
    }
}
