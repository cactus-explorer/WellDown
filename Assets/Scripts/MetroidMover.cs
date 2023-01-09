using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidMover : MonoBehaviour {

    private GameObject player;
    public float speed = 1;
    public float lookSpeed = 8;
    private float lookUpdate;
    public float lookUpdateSpeed = 1;
    private int i = 0;
    private Vector3 AdjustedPlayerPos;

    // Use this for initialization
    void Start () {
        
        lookUpdate = Time.time;
        //print(transform.parent.name);
        if (transform.parent.name.Contains("Bubble"))
        {
            lookUpdateSpeed = 1f;
        }
        if (transform.parent.name.Contains("Bat"))
        {
            lookUpdateSpeed = .1f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player");
        if (Time.time >= lookUpdate)
        {
            i = 0;
            lookUpdate = Time.time + lookUpdateSpeed;
        }
        if (i < 20)
        {
            AdjustedPlayerPos = player.transform.position + new Vector3(0, 1/2, 0);
            Quaternion toRotation = Quaternion.LookRotation(AdjustedPlayerPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * lookSpeed);
            i++;
        }

        //transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}
