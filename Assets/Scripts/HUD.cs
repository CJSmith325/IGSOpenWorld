using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public static HUD Instance;

    public Text HealthText;
    public float PlayerRegen;
    public float PlayerHealth;
    public float PlayerMaxHealth;

    public Image HealthImage;
    public Image bloodEffect;

    public float regenTimer;
    public float fill;
    public float healthPct;

    public GameObject GameOverCanvas;

    private void Start()
    {
        Instance = this;
    }


    void Update()
    {
        HealthText.text = PlayerHealth + "/" + PlayerMaxHealth;
        
        regenTimer -= Time.deltaTime;

        if (regenTimer <= 0f)
        {
            PlayerHealth += PlayerRegen;

            if (PlayerHealth > PlayerMaxHealth)
            {
                PlayerHealth = PlayerMaxHealth;
                regenTimer = 10f;

            }

        }

        fill = (PlayerHealth * 100 / PlayerMaxHealth);
        HealthImage.fillAmount = fill / 100;

        healthPct = (float)PlayerHealth / (float)PlayerMaxHealth;

        //change blood overlay to have opacity cooresponding to the remainging health
        bloodEffect.color = new Color(1f, 1f, 1f, 1f - healthPct);

    }
    public void TakeDamage(int dmg)
    {
        PlayerHealth -= dmg;
        regenTimer = 10f;
        if (PlayerHealth <= 0)
        {
            //death mechanic go here
            GameOver();

        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        System.Threading.Thread.Sleep(3000);
        //GameOverCanvas.SetActive(true);
        Cursor.visible = true;
        Respawn.Instance.PlayerRespawn();
    }
}
