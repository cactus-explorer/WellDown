using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieBoxScript : MonoBehaviour {

    PlayerScript player;
    public int health;
    public int gems;
    private GameObject parent;
    public GameObject smallGem;
    public GameObject bigGem;
    public bool death;
    public bool stompable = true;

    // Use this for initialization
    void Start () {
        
        parent = transform.parent.gameObject;
        if(parent.name.Contains("Metroid"))
        {
            health = 3;
            gems = 6;
        }
        if (parent.name.Contains("Frog"))
        {
            health = 4;
            gems = 20;
        }
        if (parent.name.Contains("Worm"))
        {
            health = 4;
            gems = 20;
        }
    }

    //new Vector3(spawn.position.x + Random.Range(-.5f, .5f), spawn.position.y, spawn.position.z + Random.Range(-.5f, .5f))

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && stompable)
        {
            int big = gems / 5;
            int small = gems % 5;
            while (big > 0)
            {
                Transform spawn = this.transform;
                Instantiate(bigGem, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
                big--;
            }
            while (small > 0)
            {
                Transform spawn = this.transform;
                Instantiate(smallGem, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
                small--;
            }
            player.murder = true;
            Destroy(transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
		if(death)
        {
            player.combo++;
            int big = gems / 5;
            int small = gems % 5;
            while (big > 0)
            {
                Transform spawn = this.transform;
                Instantiate(bigGem, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
                big--;
            }
            while (small > 0)
            {
                Transform spawn = this.transform;
                Instantiate(smallGem, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
                small--;
            }
            Destroy(transform.parent.gameObject);
        }
	}
}
