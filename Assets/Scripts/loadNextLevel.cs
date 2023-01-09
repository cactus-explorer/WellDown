using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextLevel : MonoBehaviour
{
    bool levelAlreadyChanged;

    // Start is called before the first frame update
    void Start()
    {
        levelAlreadyChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !levelAlreadyChanged)
        {
            levelAlreadyChanged = true;
            print("levelchange started");
            other.transform.SetPositionAndRotation(new Vector3(5,54,5), transform.rotation);
            other.GetComponent<PlayerScript>().levelUp();
            SceneManager.LoadScene("Underground");
        }
    }
}
