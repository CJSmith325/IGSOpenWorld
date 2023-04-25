using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{

    public static WeaponStats Instance;

    public GameObject Weapon;
    public GameObject farticleEffect;

    //basic attack vars
    public float baseDamage, damageValue, durability, attackSpeed, attackRange;

    //damage mods
    public float critMod, critChance, critDamage;
    public bool crit;

    //attack timers
    public float attackCooldown;

    public bool isSword;
    public bool canAttack;

    //Sound Effects
    public AudioSource attackSound, slash, critSlash, chop, critChop;
    private float rand;

    //Image Icons
    public Image damageIcon, speedIcon;
    private float damageWidth, speedWidth;

    private void Start()
    {
        Instance = this;

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

        damageWidth = Mathf.Lerp(damageWidth, (baseDamage / 150f), 5f * Time.deltaTime);
        speedWidth = Mathf.Lerp(speedWidth, attackSpeed, 5f * Time.deltaTime);
        
        damageIcon.fillAmount = damageWidth;
        speedIcon.fillAmount = speedWidth;

        if (canAttack)
        {
            if (Input.GetKeyDown(WeaponSwitch.Instance.switchWeapon))
            {
                WeaponSwitch.Instance.SwitchWeapons();
            }
            else if (Input.GetButtonDown("1"))
            {
                WeaponSwitch.Instance.SwitchWeapons(0);
            }
            else if (Input.GetButtonDown("2"))
            {
                WeaponSwitch.Instance.SwitchWeapons(3);
            }
            else if (Input.GetButtonDown("3"))
            {
                WeaponSwitch.Instance.SwitchWeapons(6);
            }
            else if (Input.GetButtonDown("4"))
            {
                WeaponSwitch.Instance.SwitchWeapons(9);
            }
        }
    }

    public void SwordSwing()
    {
        canAttack = false;
        NoisyBoi.Instance.SwordSwing.Play();


        CriticalHit();

        Animator swordSwing = Weapon.GetComponent<Animator>();
        swordSwing.SetTrigger("Sword Swing 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }

    public void SwordChop()
    {
        canAttack = false;
        NoisyBoi.Instance.SwordSwing.Play();


        CriticalHit();

        Animator swordSwing = Weapon.GetComponent<Animator>();
        swordSwing.SetTrigger("Sword Chop 1");

        PlayerMovement.Instance.HitMarker(damageValue);

        StartCoroutine(AttackReset());
    }

    public void AxeSwing()
    {
        canAttack = false;
        NoisyBoi.Instance.AxeSwing.Play();


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
        NoisyBoi.Instance.AxeSwing.Play();


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
            crit = false;
        }
        else
        {
            Debug.Log("CRIT!!");
            damageValue = critDamage;
            attackSound = critSlash;
            crit = true;
        }
    }
}
