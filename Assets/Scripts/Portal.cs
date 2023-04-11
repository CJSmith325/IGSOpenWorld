using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    public GameObject outsideScreen;
    bool isWin = false;

    private void OnTriggerEnter(Collider other)
    {
        //Time.timeScale = 0.0f;
        Time.timeScale = 1f;

        outsideScreen.SetActive(true);

        isWin = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;



    }
    public void Yes()
    {
        OnShrekClick();
    }
    public void OnShrekClick()
    {
        SceneManager.LoadScene("Planet attack");
        Time.timeScale = 1f;
    }

}
