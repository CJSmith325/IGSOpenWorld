using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static Pause Instance;
    //public Canvas pauseCanvas;
    public GameObject pauseCanvas;

    public Notes note;
    public Notes note1;

   // bool Swap = false;

    public KeyCode pauseButton;

    public void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetKeyDown(pauseButton))
        {
            mPause();
        }
    }

     

    public void mPause()
    {
        //Removing this allows you to pause but brings back the note pause menu issue

        if (note.noteUI.activeSelf == false)
            if (note1.noteUI.activeSelf == false)


                //Swap = !Swap;
                if (Time.timeScale == 1)
                {
                    Debug.Log("About to change timescale");
                    Time.timeScale = 0;
                    Debug.Log(" timescale");
                    Debug.Log("About to lock cursor");
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Debug.Log("cursor locked");
                    //pauseCanvas.enabled = true;
                    pauseCanvas.SetActive(true);
                }
                else if (Time.timeScale == 0)
                {
                    Debug.Log("About to change timescale");
                    Time.timeScale = 1;
                    Debug.Log("timescale");
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    //pauseCanvas.enabled = false;
                    pauseCanvas.SetActive(false);

                }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
    }
}
