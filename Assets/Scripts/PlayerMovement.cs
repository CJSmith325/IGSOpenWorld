using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;

    public CharacterController controller;

    //move speeds and forces
    public float speed = 12f;
    public float sprintMod = 1.5f;
    public float crouchMod = .5f;
    private float gravity = -9.81f;
    public float jumpHeight = 3f;
    private float slideTimer = 1.0f;
    public float slideMod = 2f;

    //Vector Calculus
    Vector3 velocity;
    Vector3 move;

    //touching grass
    public bool isGrounded;
    public bool isSwimming;
    public float groundDistance = 1f;
    private float startY = 1f;
    private float crouchY = .5f;
    public float currentY;
    public Transform groundCheck;
    public LayerMask groundMask;

    //hit detection
    public LayerMask enemyMask;

    //player morphs
    public Transform capsule;

    //player camera
    public Camera mainCam;
    Vector3 hitPoint;

    private void Start()
    {
        Instance = this;
        currentY = startY;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isSwimming)
        {
            x /= 1.5f;
            z /= 1.5f;
        }

        move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)         //Sprint Code 
        {
            controller.Move(move * (speed * sprintMod) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && isGrounded) //Crouch code
        {
            Debug.DrawRay((this.transform.position), Vector3.down * 3f, Color.cyan);        //testing ray

            currentY = Mathf.Lerp(currentY, crouchY, 10f * Time.deltaTime);
            capsule.transform.localScale = new Vector3(1.0f, currentY, 1.0f);

            if (z > 0 && slideTimer > 0)
            {
                controller.Move(move * speed * slideMod * Time.deltaTime);
                slideTimer -= Time.deltaTime;
            }
            else
            {
                controller.Move(move * speed * crouchMod * Time.deltaTime);
            }

        }
        else
        {
            currentY = Mathf.Lerp(currentY, startY, 10f * Time.deltaTime);
            capsule.transform.localScale = new Vector3(1.0f, currentY, 1.0f);
            controller.Move(move * speed * Time.deltaTime);
            slideTimer = 1f;
        }

        //Jump Code
        if (Input.GetButton("Jump") && (isGrounded || isSwimming))
        {
            if (isSwimming && !isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
            }
            else
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        controller.height = currentY * 2f;

        if (!isSwimming)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y += gravity * 0.15f * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void HitMarker(float damage)
    {
        Vector3 spherePos = this.transform.position + Vector3.Normalize(move);
        int range = 6;
        Collider[] hit = Physics.OverlapSphere(spherePos, range / 2f, enemyMask);

        RaycastHit ray;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out ray, range + 2f))
        {
            Debug.Log("ray.point: " + ray.point);
        }

        //check each hit for a health script and do damage
        foreach (Collider coll in hit)
        {
            //Debug.Log(coll.gameObject.name + " hit");
            if (coll.gameObject.GetComponent<EnemyHealth>() != null)
            {
                Debug.Log(coll.gameObject.name + " Current Health: " + coll.gameObject.GetComponent<EnemyHealth>().health);
                coll.gameObject.GetComponent<EnemyHealth>().enemyTakeDamage(damage);
                //coll.gameObject.GetComponent<EnemyHealth>().particleSpawn = ray.point;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isSwimming = true;
        }    
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isSwimming = false;
        }
    }
}
