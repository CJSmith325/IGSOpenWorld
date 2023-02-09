using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    public GameObject winScreen;
    bool isWin = false;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0.0f;

        winScreen.SetActive(true);

        isWin = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
