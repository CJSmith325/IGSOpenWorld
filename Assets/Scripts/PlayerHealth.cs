using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health; //Keeps track of current health
    public int maxHealth = 100; //Max full health

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


   public void TakeDamage(int amount) //amount = how much damage the player takes
    {
        health -= amount;
        if(health <= 0)
        {

            //Destroy(gameObject); //If damage takes the player to zero or below, then the player will be destroyed
        }
    }
}
