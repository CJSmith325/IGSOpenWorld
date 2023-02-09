using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTest : MonoBehaviour
{
    //public GameObject explosionEffect;
    public GameObject gameOverCanvas;    //makes game over ui variable
    bool isGameOver = false;   //set it to false

    private void OnTriggerEnter(Collider other)
    {
        Vector3 particleSpawnPoint = other.transform.position;
        //Instantiate(explosionEffect, particleSpawnPoint, Quaternion.identity);

        Camera.main.transform.SetParent(null);

        //Destroy() is the base function for destroying components and objects in a scene
        //You need to specify that you are reffering to a game object.
        //Destroy(this) for instance, will destroy the component, not the object.
        //Destroy(this.gameObject) will destroy the object where this component is.
        Destroy(other.gameObject);

        //pause the game
        Time.timeScale = 0.0f;

        //Shows the button when the game is paused.
        gameOverCanvas.SetActive(true);

        //When ispaused is false, this line will set it to true
        isGameOver = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}


