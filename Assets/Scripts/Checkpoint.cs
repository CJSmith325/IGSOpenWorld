using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Respawn.Instance.TouchingSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            //Debug.Log("A Spawnpoint is being Touched. - reach 1");
            Respawn.Instance.TouchingSpawn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            //Debug.Log("A Spawnpoint is no longer being Touched.");
            Respawn.Instance.TouchingSpawn = false;
        }
    }
}
