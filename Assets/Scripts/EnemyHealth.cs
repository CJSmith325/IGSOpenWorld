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
            enemyDeath();
        }
    }

    public void enemyDeath()
    {
        //find animator and play death animation
        Animator enemyAnim = gameObject.GetComponent<Animator>();
        enemyAnim.SetTrigger("Death");

        //remove movement scripts
        EnemyAi enemyAi = gameObject.GetComponent<EnemyAi>();
        EnemyMovement enemyMove = gameObject.GetComponent<EnemyMovement>();
        enemyAi.enabled = false;
        enemyMove.enabled = false;

        //StartCoroutine(StartFade());

        //wait 5 seconds and dissappear
        Destroy(this.gameObject, 5f);
    }

    IEnumerator StartFade()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Start Fade");

      
        Renderer[] bodyParts = (Renderer[])Object.FindObjectsOfType(typeof(Renderer));

        float step = Time.deltaTime;

        foreach (Renderer part in bodyParts)
        {
            if (part.gameObject.GetComponent<Collider>() != null)
            {
                Destroy(part.gameObject.GetComponent<Collider>());
            }
                
            Color fade = part.material.color;
            fade = new Color(fade.r, fade.g, fade.b, fade.a - .1f);

            part.material.color = fade;
                
        }

      
    }

}
