using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static Pause Instance;
   // public Canvas pauseCanvas;

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
        if (note.noteUI == false)
            if (note1.noteUI == false)
                //Swap = !Swap;
                 if (Time.timeScale == 1)
                 {
                    Time.timeScale = 0;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                   // pauseCanvas.enabled = true;
                  }
                 else if (Time.timeScale == 0)
                 {
                    Time.timeScale = 1;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    //pauseCanvas.enabled = false;
                }
    }
}
