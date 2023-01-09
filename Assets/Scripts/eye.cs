using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    public int triggerDistance = 20;
    public int speed = 0;
    GameObject player;
    bool triggered;
    public float lookSpeed = 8;
    bool lockedOn;
    public float rotationSpeed = 5;
    private float rotsToGo;
    bool goingInForTheKill;
    GameObject visible;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        lockedOn = false;
        rotsToGo = 360 * 3;
        goingInForTheKill = false;
        visible = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (!triggered)
        {
            double distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < triggerDistance)
            {
                triggered = true;
            }
        }
        if (triggered && !goingInForTheKill && !lockedOn)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
            transform.LookAt(player.transform.position);
            double distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < 3)
            {
                lockedOn = true;
            }
        }
        if (lockedOn)
        {
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0,0,0);
            //transform.Rotate(rotationSpeed, 0.0f, 0.0f, Space.World);
            rotsToGo-=rotationSpeed;
            if (rotsToGo <= 0)
            {
                goingInForTheKill = true;
                visible.transform.Translate(0, -4, 0, Space.Self);
            }
        }
        //if (goingInForTheKill && visible.transform.localPosition.y > 0)
        //{
        //    visible.transform.Translate(0, -1, 0, Space.Self);
        //}
        //if(!goingInForTheKill && visible.transform.localPosition.y > 4)
        //{
         //   visible.transform.Translate(0, 1, 0, Space.Self);
        //}
    }
}
