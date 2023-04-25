using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public static PowerupScript Instance;
    public HUD hud;
    public PlayerMovement playerMovement;
    public int powerupType;
    public AudioSource source;
    public AudioClip powerupSound;
    public Rigidbody rb;
    public Transform player;
    public Vector3 distanceFromPlayer;
    void Start()
    {
        Instance = this;
        hud = GameObject.Find("Player").GetComponent<HUD>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = transform.position - player.position;
        if (distanceFromPlayer.magnitude <= 1.6f)
        {
            PickupPowerup();
            source.PlayOneShot(powerupSound);
        }
    }

    
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickupPowerup();
            Destroy(gameObject);
        }
    }*/


    public void PickupPowerup()
    {
        if (powerupType == 1 && hud.PlayerMaxHealth < 399)
        {
            hud.PlayerMaxHealth += 3;
            hud.PlayerHealth = hud.PlayerMaxHealth;
        }
        else if (powerupType == 2)
        {
            hud.bonusDamage += 3;
        }
        else if (powerupType == 3 && playerMovement.speed < 14.99f)
        {
            playerMovement.speed += 0.04f;
        }
        powerupType = 0;

        NoisyBoi.Instance.PowerUp.Play();
        Destroy(gameObject);
    }
}
