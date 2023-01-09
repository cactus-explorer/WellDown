using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    PlayerScript player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player.hurt = true;
            //Destroy(transform.gameObject);
        }
    }
}
