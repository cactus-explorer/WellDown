using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metroid : MonoBehaviour {

    Quaternion rot;
    GameObject mover;
    public int speed = 0;
    GameObject player;
    bool triggered;
    int triggerDistance;

    // Use this for initialization
    void Start()
    {
        mover = transform.GetChild(0).gameObject;
        triggered = false;
        if (name.Contains("Bubble"))
        {
            triggerDistance = 20;
        }
        if (name.Contains("Bat"))
        {
            triggerDistance = 4;
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        player = GameObject.Find("Player");
        if (!triggered)
        {
            double distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < triggerDistance)
            {
                triggered = true;
            }
        }
        if (triggered)
        {
            transform.Translate(mover.transform.forward * Time.deltaTime * speed);
        }
    }
}
