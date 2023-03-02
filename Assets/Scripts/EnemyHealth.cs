using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;


    void Start()
    {
        health = maxHealth;

    }

    void Update()
    {
        
    }

    public void enemyTakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Death Damage: " + damage);
            Destroy(this.gameObject);

            /*
            Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
            player = playerObj.transform;
            launchAngle = this.gameObject.transform.position - player.position;
            rb.AddForce(launchAngle * explosionForce);  //launch the ragdoll
            */

        }
    }

}
