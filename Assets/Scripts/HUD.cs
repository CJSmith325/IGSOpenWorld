using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public static HUD Instance;

    public Text HealthText;
    public int PlayerRegen;
    public int PlayerHealth;
    public int PlayerMaxHealth;

    public Image HealthImage;
    public Image bloodEffect;

    public float regenTimer;
    public float fill;
    public float healthPct;

    private void Start()
    {
        Instance = this;
    }


    void Update()
    {
        HealthText.text = PlayerHealth + "/" + PlayerMaxHealth;
        
        regenTimer += Time.deltaTime;
        if (regenTimer >= 1)
        {
            PlayerHealth += PlayerRegen;
            if (PlayerHealth > PlayerMaxHealth)
            {
                PlayerHealth = PlayerMaxHealth;
            }
            regenTimer = 0;
        }
        fill = (PlayerHealth * 100 / PlayerMaxHealth);
        HealthImage.fillAmount = fill / 100;
        if (PlayerHealth <= 0)
        {
            //death mechanics go here
        }

        healthPct = (float)PlayerHealth / (float)PlayerMaxHealth;

        //change blood overlay to have opacity cooresponding to the remainging health
        bloodEffect.color = new Color(1f, 1f, 1f, 1f - healthPct);

    }
    public void TakeDamage(int dmg)
    {
        PlayerHealth -= dmg;
        if (PlayerHealth <= 0)
        {
            //death mechanic go here
            Time.timeScale = 0;
            Respawn.Instance.PlayerRespawn();

        }
    }
}
