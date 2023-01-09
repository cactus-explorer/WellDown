using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class crawler : MonoBehaviour
{
    private Rigidbody rb;
    public int moveSpeed;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Random.Range(0, 2) == 0)
        {
            direction = -90;
        }
        else
        {
            direction = 90;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .5f))
        {
            transform.Rotate(0, direction, 0, Space.World);
        }
        rb.AddForce(transform.forward * moveSpeed * Time.deltaTime, ForceMode.Force);
    }
}
