using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class turtle : MonoBehaviour
{
    private Rigidbody rb;
    public int movespeed = 200;
    int currentMoveSpeed;
    public float checkFloorAngle = -45;
    float pauseTime;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        pauseTime = Time.time + Random.Range(0.1f, 10f);
        rb = GetComponent<Rigidbody>();
        currentMoveSpeed = movespeed;
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(transform.forward * currentMoveSpeed * Time.deltaTime, ForceMode.Impulse);
        Debug.DrawRay(transform.position, transform.TransformVector(0, checkFloorAngle, 1) * 2);
        //print(pauseTime);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .5f) || !Physics.Raycast(transform.position, transform.TransformVector(0, -.5f, 1), 1.5f))
        {
            transform.Rotate(0, 180, 0, Space.World);
        }
        if (Time.time >= pauseTime)
        {
            if (paused)
            {
                currentMoveSpeed = movespeed;
                //print('a');
            }
            if (!paused)
            {
                currentMoveSpeed = 0;
                //print('b');
            }
            paused = !paused;
            pauseTime = Time.time + Random.Range(0.1f, 20f);
        }
    }
}
