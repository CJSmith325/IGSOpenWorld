using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static Pause Instance;

    bool Swap = false;

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
        //Swap = !Swap;
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


        }
    }
}
