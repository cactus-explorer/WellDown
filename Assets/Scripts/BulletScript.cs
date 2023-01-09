using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletspeed;
    public float lifespan;
    private float death;

	// Use this for initialization
	void Start () {
        death = Time.time + lifespan;
	}

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Destructable")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } 
        if (tag == "Enemy")
        {
            dieBoxScript script = other.GetComponentInChildren<dieBoxScript>();
            script.death = true;
            Destroy(gameObject);
        }
        if (tag != "Destructable" && tag != "Wall" && tag != "Player" && tag != "Enemy" && tag != "LargeGem" && tag != "SmallGem")
        {
            Destroy(gameObject);
        }
    }

    void Update () {
        if (Time.time >= death)
            Destroy(gameObject);
        transform.Translate(0.0f, -1f * bulletspeed* Time.deltaTime, 0.0f * Time.deltaTime);
	}
}
