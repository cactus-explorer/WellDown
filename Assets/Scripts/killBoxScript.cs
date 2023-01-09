using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBoxScript : MonoBehaviour {

    PlayerScript player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerScript>(); ;
        }
        if (other.gameObject.tag == "Player")
        {
            player.hurt = true;
            //Destroy(transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
