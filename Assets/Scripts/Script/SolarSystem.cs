using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject Son;
    public GameObject Earth;
    public GameObject Moon;

    void Start()
    {
        Vector3 earthPos = Earth.transform.position;
        earthPos.x += 4;
        Earth.transform.position = earthPos;
        Moon.transform.localPosition = new Vector3(Moon.transform.localPosition.x + 1.8f, Moon.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        Earth.transform.RotateAround(Son.transform.position, Vector3.up, 5 * Time.deltaTime);
        Earth.transform.Rotate(Earth.transform.up, 300 * Time.deltaTime, Space.World);
        Moon.transform.RotateAround(Earth.transform.position, Earth.transform.right, 120 * Time.deltaTime);
    }
}
