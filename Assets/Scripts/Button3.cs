using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    public GameObject text;

    public bool powerIsOn;

    private bool inReach;

    public Animator ANI;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        powerIsOn = false;

        ANI.SetBool("PuzzleDoor", false);
        ANI.SetBool("PuzzleOpen", true);
    

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            powerIsOn = true;

            ANI.SetBool("PuzzleOpen", true);
            ANI.SetBool("PuzzleDoor", true);

            inReach = false;
            text.SetActive(false);
        }



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


}

