using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBox : MonoBehaviour
{
    PlayerScript player;
    string weaponInside;
    string BoxEffect;
    int randomB;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        int randomA = Random.Range(1, 8);
        switch (randomA)
        {
            case 1:
                weaponInside = "Machine Gun";
                break;
            case 2:
                weaponInside = "Burst";
                break;
            case 3:
                weaponInside = "Triple";
                break;
            case 4:
                weaponInside = "Puncher";
                break;
            case 5:
                weaponInside = "Shotgun";
                break;
            case 6:
                weaponInside = "Laser";
                break;
            case 7:
                weaponInside = "Noppy";
                break;
        }
        randomB = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.gunChange(weaponInside);
            switch (randomB) {
                case 1:
                    player.healthUp();
                    break;
                case 2:
                    player.bulletMax+=2;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
