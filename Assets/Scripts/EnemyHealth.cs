using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject knightParticle;
    public Vector3 particleSpawn;
    
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    public void enemyTakeDamage(float damage)
    {
        health -= damage + Random.Range(0, 10);

        spawnDamageParticle();

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

        StartCoroutine(StartFade());

        //wait 5 seconds and dissappear
        Destroy(this.gameObject, 5f);
    }

    IEnumerator StartFade()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Start Fade");

        InvokeRepeating("DirkNowitzki", 0f, .1f);
    }


    public void DirkNowitzki()
    {
        float fadeVal = .7f;
        float fadeStep = 2f;
        float step = Time.deltaTime * fadeStep;

        Renderer[] bodyParts = gameObject.GetComponentsInChildren<Renderer>();


        foreach (Renderer part in bodyParts)
        {
            if (part.gameObject.GetComponent<Collider>() != null)
            {
                //remove collision physics
                Destroy(part.gameObject.GetComponent<Collider>());
            }

            //find some way to fade the material out
            
            part.material.color = new Color(part.material.color.r, part.material.color.g, part.material.color.b, part.material.color.a * fadeVal);
        
        }

    }

    public void spawnDamageParticle()
    {
        knightParticle = WeaponStats.Instance.farticleEffect;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        particleSpawn = transform.position - (transform.position - player.transform.position).normalized;
        //particleSpawn -= (transform.position - player.transform.position).normalized;

        Debug.Log("particleSpawn" + particleSpawn);

        Instantiate(knightParticle, particleSpawn, Quaternion.identity);

    }
}


