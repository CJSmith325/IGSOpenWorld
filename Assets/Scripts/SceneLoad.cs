using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void OnStartClick() 
    {
        SceneManager.LoadScene("");
    }

    public void OnInstructionsClick()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void OnExitClick()
    {
        Application.Quit();
    }
}
