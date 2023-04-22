using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    //public AudioSource doorSound;

    public bool inReach;



    void Start()
    {
        inReach = false;
        DoorCloses();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
    }

    void DoorOpens()
    {
        Debug.Log("It Opens");
        door.SetBool("open", true);
        door.SetBool("closed", false);
        //doorSound.Play();

        pickUpKeys.Instance.keyImage.SetActive(false);

    }

    void DoorCloses()
    {
        Debug.Log("It Closes");
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }
}
