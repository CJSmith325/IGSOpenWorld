using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCastle : MonoBehaviour
{
    public GameObject outsideScreen;
    bool isWin = false;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0.0f;

        outsideScreen.SetActive(true);

        isWin = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
