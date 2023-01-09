using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveSpawn : MonoBehaviour
{

    public GameObject powerUp;
    public GameObject shopKeep;

    // Start is called before the first frame update
    void Start()
    {
        GameObject placeholderForGoodName;
        placeholderForGoodName = Instantiate(powerUp, new Vector3() + transform.position, new Quaternion());
        placeholderForGoodName.transform.parent = transform;
        placeholderForGoodName.transform.localPosition = new Vector3(0f, -4.5f, -12f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
