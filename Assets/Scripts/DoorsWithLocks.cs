using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithLocks : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject keyINV;

    //public AudioSource doorSound;
    //public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;


    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && hasKey)
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
        if (keyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            locked = true;
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetButtonDown("Interact"))
        {
            unlocked = true;
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            //lockedSound.Play();
        }
    }

    void DoorOpens()
    {
        if (unlocked)
        {
            door.SetBool("open", true);
            door.SetBool("closed", false);
            //doorSound.Play();
            pickUpKeys.Instance.keyImage.SetActive(false);
            keyINV.SetActive(false);
            openText.SetActive(false);

        }

    }

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("open", false);
            door.SetBool("closed", true);

        }

    }
}