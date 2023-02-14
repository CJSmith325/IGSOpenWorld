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

    //public GameObject Axe3;
    //public GameObject Axe3OB;

    //public GameObject knife;
    //public GameObject knifeOB;


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
        //if (Axe3OB.activeInHierarchy)
        //{
        //    Axe3.SetActive(true);
        //}
        //else
        //{
        //    Axe3.SetActive(false);
        //}
        //if (knifeOB.activeInHierarchy)
        //{
        //    knife.SetActive(true);
        //}
        //else
        //{
        //    knife.SetActive(false);
        //}
    }
    public void TakeDamage(int dmg)
    {
        PlayerHealth -= dmg;
        if (PlayerHealth <= 0)
        {
             //death mechanic go here
        }
    }
}
