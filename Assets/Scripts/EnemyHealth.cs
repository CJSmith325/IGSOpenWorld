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

            Animator enemyAnim = gameObject.GetComponent<Animator>();
            enemyAnim.SetTrigger("Death");

            Debug.Log("Death Animation");

            EnemyAi enemyAi = gameObject.GetComponent<EnemyAi>();
            enemyAi.enabled = false;
            EnemyMovement enemyMove = gameObject.GetComponent<EnemyMovement>();
            enemyMove.enabled = false;

            //wait 5 seconds and dissappear
            Destroy(this.gameObject, 5f);

        }
    }

}
