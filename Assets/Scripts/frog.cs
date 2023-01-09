using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour {

    private GameObject player;
    public float step;
    public float jumpDelay;
    float jumpTime;
    private Rigidbody rb;
    Vector3 v;
    public float jumpModifier;
    public float jumpBonus = 6;
    public float jumpPush;
    float dist;
    public float jumpInhibit;
    public float maxDistance = 20;
    public float lookSpeed = 1;

    // Use this for initialization
    void Start () {
        jumpTime = Time.time + jumpDelay;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player");
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookSpeed);
        if (Time.time >= jumpTime)
        {
            v = rb.velocity;
            dist = player.transform.position.y + 1 - transform.position.y;
            // print(dist);
            if (dist <= maxDistance)
                v.y += (jumpModifier * jumpInhibit * dist) + jumpBonus;
            rb.velocity = v;
            if (dist <= maxDistance)
                rb.velocity += transform.forward * jumpPush;
            jumpTime = Time.time + jumpDelay;

        }
    }
}
