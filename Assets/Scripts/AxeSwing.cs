using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("Axe Swing Test");
        }

        //if (Input.GetKeyDown(KeyCode.R))
        {
           // GetComponent<Animator>().Play("Axe Swing Test");
        }
    }
}
