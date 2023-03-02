using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{

    public int totalWeapons;
    public int activeWeapon;

    public KeyCode switchWeapon;

    public GameObject[] weapons;
    public GameObject axe1, axe2, axe3, dblAxe1, dblAxe2, dblAxe3, sword1, sword2, sword3, bigSword1, bigSword2, bigSword3;


    public Image weaponIcon;
    public Sprite[] weaponWheel = new Sprite[12];

    void Start()
    {
        totalWeapons = 12;
        activeWeapon = 0;

        weapons = new GameObject[totalWeapons];
        weaponIcon.sprite = weaponWheel[activeWeapon];


        weapons[0] = axe1;
        weapons[1] = axe2;
        weapons[2] = axe3;
        weapons[3] = dblAxe1;
        weapons[4] = dblAxe2;
        weapons[5] = dblAxe3;
        weapons[6] = sword1;
        weapons[7] = sword2;
        weapons[8] = sword3;
        weapons[9] = bigSword1;
        weapons[10] = bigSword2;
        weapons[11] = bigSword3;


        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        weapons[3].SetActive(false);
        weapons[4].SetActive(false);
        weapons[5].SetActive(false);
        weapons[6].SetActive(false);
        weapons[7].SetActive(false);
        weapons[8].SetActive(false);
        weapons[9].SetActive(false);
        weapons[10].SetActive(false);
        weapons[11].SetActive(false);

    }

    private void Update()
    {
        if(Input.GetKeyDown(switchWeapon))
        {
            SwitchWeapons();
        }
        else if (Input.GetButtonDown("1"))
        {
            SwitchWeapons(0);
        }
        else if (Input.GetButtonDown("2"))
        {
            SwitchWeapons(3);
        }
        else if (Input.GetButtonDown("3"))
        {
            SwitchWeapons(6);
        }
        else if (Input.GetButtonDown("4"))
        {
            SwitchWeapons(9);
        }

    }

    public void SwitchWeapons()
    {
        activeWeapon = (activeWeapon + 1) % totalWeapons;
        weaponIcon.sprite = weaponWheel[activeWeapon];

        for (int i = 0; i < totalWeapons; i++)
        {
            if (i == activeWeapon)
            {
                //Set the chosen Weapon to active
                weapons[i].SetActive(true);
                //crosshairs[i].enabled = true;
                //Txt[i].enabled = true;
            }
            else
            {
                //set all other Weapons to inactive
                weapons[i].SetActive(false);
                //crosshairs[i].enabled = false;
                //Txt[i].enabled = false;
            }
        }
    }

    public void SwitchWeapons(int num)
    {
        activeWeapon = num;
        weaponIcon.sprite = weaponWheel[num];

        for (int i = 0; i < totalWeapons; i++)
        {
            if (i == activeWeapon)
            {
                //Set the chosen Weapon to active
                weapons[i].SetActive(true);
                //crosshairs[i].enabled = true;
                //Txt[i].enabled = true;
            }
            else
            {
                //set all other Weapons to inactive
                weapons[i].SetActive(false);
                //crosshairs[i].enabled = false;
                //Txt[i].enabled = false;
            }
        }
    }
}
