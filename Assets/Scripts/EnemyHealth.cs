using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float healthPct;
    public GameObject knightParticle;
    public GameObject critParticle;
    public Vector3 particleSpawn;
    public GameObject[] drop;
    public HUD hud;
    public Image healthBar, healthBackground;
    
    void Start()
    {
        health = maxHealth;
        hud = GameObject.Find("Player").GetComponent<HUD>();
    }



    public void enemyTakeDamage(float damage)
    {
        health -= damage + Random.Range(0, hud.bonusDamage);
        

        spawnDamageParticle();

        if (health <= 0)
        {
            Debug.Log("Death Damage: " + damage);
            enemyDeath();
            healthBar.enabled = false;
            healthBackground.enabled = false;
        }
        else
        {

            healthPct = health / maxHealth;
            healthBar.fillAmount = healthPct;

            if (health < maxHealth)
            {
                healthBar.enabled = true;
                healthBackground.enabled = true;
            }

            //Knockback();
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
        drops();
        //wait 5 seconds and dissappear
        Destroy(this.gameObject, 5f);
    }


    public void drops()
    {
        if (Random.Range(1, 5) == 1)
        {
            Instantiate(drop[0], transform.position, Quaternion.identity);
        }
        if (Random.Range(1, 10) == 1)
        {
            Instantiate(drop[1], transform.position, Quaternion.identity);
        }
        if (Random.Range(1, 10) == 1)
        {
            Instantiate(drop[2], transform.position, Quaternion.identity);
        }

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
            part.material.color = new Color(part.material.color.r * fadeVal, part.material.color.g * fadeVal, part.material.color.b * fadeVal, part.material.color.a);
            //part.material.color = new Color(part.material.color.r, part.material.color.g, part.material.color.b, part.material.color.a * fadeVal);

        }

    }

    public void spawnDamageParticle()
    {
        knightParticle = WeaponStats.Instance.farticleEffect;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        particleSpawn = transform.position - (transform.position - player.transform.position).normalized;
        //particleSpawn -= (transform.position - player.transform.position).normalized;

        Debug.Log("particleSpawn" + particleSpawn);

        if (WeaponStats.Instance.crit)
        {
            Instantiate(critParticle, particleSpawn, Quaternion.identity);
        }
        else
        {
            Instantiate(knightParticle, particleSpawn, Quaternion.identity);
        }
    }

}


