using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    //basic vars
    private float minX = -90f;
    private float maxX = 90f;
    private float minY = -360f;
    private float maxY = 360f;
    public float sensivity;
    private float xRotation = 0;
    private float yRotation = 0;
    public float camMultiplier;

    //Field Of View
    public float sprintFOV;
    public float startFOV;

    //Game Objects
    public Camera mainCam;

    //pause
    public KeyCode pauseKey;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        yRotation += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        xRotation -= Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, minX, maxX);


        //sprint FOV changes
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFOV, camMultiplier * Time.deltaTime);
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, startFOV, camMultiplier * Time.deltaTime);
        }

        transform.eulerAngles = new Vector3(0, yRotation, 0);
        mainCam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0f);

    }
}
