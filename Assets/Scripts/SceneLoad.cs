using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    public static SceneLoad Instance;

    public void Start()
    {
        Instance = this;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnStartClick() 
    {
        SceneManager.LoadScene("PlayTest");
    }

    public void OnInstructionsClick()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnShrekClick()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void PickWorldClick()
    {
        SceneManager.LoadScene("PickGame");
    }

    public void TutorialWorldClick()
    {
        SceneManager.LoadScene("PlayTest");
    }

    public void OpenWorldClick()
    {
        SceneManager.LoadScene("NewTerrain");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
