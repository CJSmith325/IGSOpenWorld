using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    public GameObject text;
    public GameObject onOB;
    public GameObject offOB;
    public bool powerIsOn;
    private bool inReach;

    

    public Animator ANI;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        onOB.SetActive(false);
        offOB.SetActive(true);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && !powerIsOn)
        {
            inReach = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            powerIsOn = true;
        }

        if (powerIsOn)
        {
            ANI.SetBool("OpenGlassDoor", true);
            ANI.SetBool("IdleGlassDoor", true);

           
         
            onOB.SetActive(false);
            offOB.SetActive(true);

        }

        if (!powerIsOn)
        {
            ANI.SetBool("IdleGlassDoor", false);
            ANI.SetBool("OpenGlassDoor", true);

            onOB.SetActive(true);
            offOB.SetActive(false);
        }
    }
}
