using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor1 : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject onOB;
    public GameObject offOB;

    //public AudioSource doorSound;

    public bool inReach;


    void Start()
    {
        inReach = false;
        onOB.SetActive(false);
        offOB.SetActive(true);
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
            onOB.SetActive(true);
           
        }
        else
        {
            DoorCloses();
           
            offOB.SetActive(true);
        }
    }

    void DoorOpens()
    {
        Debug.Log("It Opens");
        door.SetBool("open", true);
        door.SetBool("closed", false);
        //doorSound.Play();
        onOB.SetActive(true);
        offOB.SetActive(false);

    }

    void DoorCloses()
    {
        Debug.Log("It Closes");
        door.SetBool("open", false);
        door.SetBool("closed", true);
        onOB.SetActive(false);
        offOB.SetActive(true);

    }
}
