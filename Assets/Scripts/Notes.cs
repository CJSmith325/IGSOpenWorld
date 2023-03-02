using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;
    //public AudioSource pickUpSound;
    public bool inReach;
    //public bool isOpen;

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);
        Time.timeScale = 1;
        inReach = false;
        //isOpen = false;
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
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            //pickUpSound.Play();
            hud.SetActive(false);
            inv.SetActive(false);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //isOpen = true;
        }
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        Time.timeScale = 1;
        Cursor.visible = false;
        //isOpen = false;
    }
}
