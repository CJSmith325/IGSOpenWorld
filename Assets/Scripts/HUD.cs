using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon1OB;
    public Image HealthImage;
    public Text HealthText;
    public int PlayerHealth;
    public int PlayerMaxHealth;

    //public GameObject Axe3;
    //public GameObject Axe3OB;

    //public GameObject knife;
    //public GameObject knifeOB;


   


    void Update()
    {
        //HealthText.text = PlayerHealth + "/" + PlayerMaxHealth;
        //HealthImage.fillAmount = PlayerHealth / PlayerMaxHealth;
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
}
