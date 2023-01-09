using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    private float lifespan = .3f;
    private float death;
    public GameObject laser;
    private bool recreated = false;

    // Use this for initialization
    void Start()
    {
        death = Time.time + lifespan;
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Destructable")
        {
            Destroy(other.gameObject);
        }
        if (tag == "Enemy")
        {
            //print("death by enemy?");
            dieBoxScript script = other.GetComponentInChildren<dieBoxScript>();
            try
            {
                script.death = true;
            } catch(System.NullReferenceException e)
            {
                print(e);
            }
        }
        if (tag == "Player")
            Destroy(gameObject);
        if (tag != "Destructable" && tag != "Wall" && tag != "Player" && tag != "Enemy" && tag != "LargeGem" && tag != "SmallGem")
        {
            print("killed by "+ other.name);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        
        if (Time.time >= death)
        {
            //print("killed by time. death: "+death+" lifespan :" +lifespan);
            Destroy(gameObject);
        }
        if (recreated == false)
        {
            Instantiate(laser, new Vector3(transform.position.x, transform.position.y - .8f, transform.position.z), transform.rotation, transform.parent);
            recreated = true;
        }
    }
}
