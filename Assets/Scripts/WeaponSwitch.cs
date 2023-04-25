using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public static WeaponSwitch Instance;

    public int totalWeapons;
    public int activeWeapon;

    public KeyCode switchWeapon;

    public GameObject[] weapons;
    public GameObject axe1, axe2, axe3, dblAxe1, dblAxe2, dblAxe3, sword1, sword2, sword3, bigSword1, bigSword2, bigSword3;


    public bool[] unlocked = new bool[12];

    public Image weaponIcon;
    public Sprite[] weaponWheel = new Sprite[12];


    void Start()
    {
        Instance = this;

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

        unlocked[0] = true;
        unlocked[1] = false;
        unlocked[2] = false;
        unlocked[3] = true;
        unlocked[4] = false;
        unlocked[5] = false;
        unlocked[6] = true;
        unlocked[7] = false;
        unlocked[8] = false;
        unlocked[9] = true;
        unlocked[10] = false;
        unlocked[11] = false;

    }

    public void SwitchWeapons()
    {
        activeWeapon = (activeWeapon + 1) % totalWeapons;

        if(unlocked[activeWeapon])
        {
            weaponIcon.sprite = weaponWheel[activeWeapon];

            EquipWeapon(activeWeapon);
        }
        else
        {
            SwitchWeapons();
        }

    }

    public void SwitchWeapons(int num)
    {
        activeWeapon = num;
        weaponIcon.sprite = weaponWheel[num];

        EquipWeapon(activeWeapon);
    }

    public void EquipWeapon(int activeWeapon)
    {

        for (int i = 0; i < totalWeapons; i++)
        {
            if (i == activeWeapon)
            {
                //Set the chosen Weapon to active
                weapons[i].SetActive(true);
            }
            else
            {
                //set all other Weapons to inactive
                weapons[i].SetActive(false);

            }
        }
    }

}
