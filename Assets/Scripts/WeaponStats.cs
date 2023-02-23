using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    public GameObject Weapon;

    //basic attack vars
    public float baseDamage, damageValue, durability, attackSpeed, attackRange;

    //damage mods
    public float critMod, critChance, critDamage;

    //attack timers
    public float attackCooldown;

    public bool isSword;
    public bool canAttack;

    //Sound Effects
    public AudioClip attackSound, slash, critSlash, chop, critChop;
    private float rand;


    private void Start()
    {

        canAttack = true;
        critDamage = baseDamage * critMod;

    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //sword + axe swing code

            attackCooldown = 1;

            if (canAttack && isSword)
            {
                SwordSwing();
            }
            else if (canAttack && !isSword)
            {
                AxeSwing();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //sword + axe chop code

            attackCooldown = 2;

            if (canAttack && isSword)
            {
                SwordChop();
            }
            else if (canAttack && !isSword)
            {
                AxeChop();
            }
        }


    }

    public void SwordSwing()
    {
        canAttack = false;

        CriticalHit();

        Animator swordSwing = Weapon.GetComponent<Animator>();
        swordSwing.SetTrigger("Sword Swing 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }

    public void SwordChop()
    {
        canAttack = false;

        CriticalHit();

        Animator swordSwing = Weapon.GetComponent<Animator>();
        swordSwing.SetTrigger("Sword Chop 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }

    public void AxeSwing()
    {
        canAttack = false;

        CriticalHit();

        Animator axeSwing = Weapon.GetComponent<Animator>();
        axeSwing.SetTrigger("Axe Swing 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }

    public void AxeChop()
    {
        //axe chop code
        canAttack = false;

        CriticalHit();

        Animator axeSwing = Weapon.GetComponent<Animator>();
        axeSwing.SetTrigger("Axe Chop 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }


    IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

   
    public void CriticalHit()
    {
        rand = Random.Range(0f, 1f);
        if (rand > critChance)
        {
            damageValue = baseDamage;
            attackSound = slash;
        }
        else
        {
            Debug.Log("CRIT!!");
            damageValue = critDamage;
            attackSound = critSlash;
        }
    }

}
