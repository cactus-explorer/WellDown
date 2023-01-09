using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBaseScript : MonoBehaviour
{
    private float lifespan = .5f;
    private float death;
    //    Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        //       playerTrans = GameObject.Find("Player").GetComponent<PlayerScript>().gameObject.transform;
        death = Time.time + lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        //        gameObject.transform.position = new Vector3(gameObject.transform.position.x, playerTrans.position.y, gameObject.transform.position.z);
        if (Time.time >= death)
        {
            //print("killed by time. death: " + death + " lifespan :" + lifespan);
            Destroy(gameObject);
        }
    }
}
