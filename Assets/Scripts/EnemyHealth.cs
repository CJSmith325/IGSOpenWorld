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
        }
    }

}
