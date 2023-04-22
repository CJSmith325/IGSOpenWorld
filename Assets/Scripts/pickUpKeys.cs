using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpKeys : MonoBehaviour
{

    public static pickUpKeys Instance;

    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public GameObject keyImage;

    //public AudioSource keySound;

    public bool inReach;

    void Start()
    {
        Instance = this;

        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
        keyImage.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            //keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            keyImage.SetActive(true);
        }
    }
}
