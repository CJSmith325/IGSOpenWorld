using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    //basic attack vars
    public float baseDamage, durability, attackSpeed, attackRange;

    //damage mods
    public float critMod, critChance, critDamage;

    //attack timers
    public float attackTime, attackTimer;

    public bool isSword;

    private void Start()
    {
 
        critDamage = baseDamage * critMod;
        attackTime = 1f / attackSpeed;
        attackTimer = attackTime;

    }


    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if (isSword)
                SwordSwing();
            else
                AxeSwing();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (isSword)
                SwordChop();
            else
                AxeChop();
        }


    }

    public void SwordSwing()
    {
        //sword swing code
    }

    public void SwordChop()
    {
        //sword chop code
    }

    public void AxeSwing()
    {
        //axe swing code
    }

    public void AxeChop()
    {
        //axe chop code
    }





}
