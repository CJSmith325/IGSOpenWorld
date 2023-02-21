using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public static HUD Instance;

    public GameObject Weapon1;
    public GameObject Weapon1OB;
    public Image HealthImage;
    public Text HealthText;
    public float regenTimer;
    public float fill;
    public int PlayerRegen;
    public int PlayerHealth;
    public int PlayerMaxHealth;

    public GameObject Weapon2;
    public GameObject Weapon2OB;

    public GameObject Weapon3;
    public GameObject Weapon3OB;

    public GameObject Weapon4;
    public GameObject Weapon4OB;


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
        if (Weapon1OB.activeInHierarchy)
        {
            Weapon1.SetActive(true);
        }
        else
        {
            Weapon1.SetActive(false);
        }
        if (Weapon2OB.activeInHierarchy)
        {
            Weapon2.SetActive(true);
        }
        else
        {
            Weapon2.SetActive(false);
        }
        if (Weapon3OB.activeInHierarchy)
        {
            Weapon3.SetActive(true);
        }
        else
        {
            Weapon3.SetActive(false);
        }
        if (Weapon4OB.activeInHierarchy)
        {
            Weapon4.SetActive(true);
        }
        else
        {
            Weapon4.SetActive(false);
        }
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
