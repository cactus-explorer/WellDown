using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class worm : MonoBehaviour
{
    private Rigidbody rb;
    public int movespeed = 200;
    public float checkFloorAngle = -45;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(transform.forward * movespeed * Time.deltaTime, ForceMode.Impulse);
        Debug.DrawRay(transform.position, transform.TransformVector(0, checkFloorAngle, 1)*2);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .5f) || !Physics.Raycast(transform.position, transform.TransformVector(0, -.5f, 1), 1.5f))
        {
            transform.Rotate(0, 180, 0, Space.World);
        }
    }
}
