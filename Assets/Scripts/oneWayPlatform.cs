using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayPlatform : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(this.transform.parent.gameObject.GetComponent<Collider>(), other, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(this.transform.parent.gameObject.GetComponent<Collider>(), other, false);
        }
    }
}
