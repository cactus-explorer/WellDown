using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    int worth;
    PlayerScript playerScript;
    float distance;
    int waitTime = 1;
    float readyToCollectTime;
    bool homing = false;
    GameObject player;
    Rigidbody rigid;
    Collider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<Collider>();

        if (name.Contains("big"))
        {
            worth = 5;
        }
        if (name.Contains("small"))
        {
            worth = 1;
        }
        readyToCollectTime = Time.time + waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= readyToCollectTime)
        {
            distance = (float)Vector3.Distance(this.transform.position, playerScript.gameObject.transform.position);
            player = playerScript.gameObject;
            if (Vector3.Distance(this.transform.position, player.transform.position) > 70)
            {
                Destroy(gameObject);
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) < 4)
            {
                homing = true;
                boxCollider.enabled = false;
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) < .5)
            {
                playerScript.gems += worth;
                Destroy(gameObject);
            }
        }
        if (homing)
        {
            transform.LookAt(player.transform);
            rigid.velocity = transform.forward * 15;
        }
    }
}
