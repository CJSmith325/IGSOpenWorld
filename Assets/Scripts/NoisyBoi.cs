using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyBoi : MonoBehaviour
{
    public static NoisyBoi Instance;

    //one shot sounds
    public AudioSource AxeSwing, SwordSwing, WeaponEquip, CriticalHit, EnemyHit, PlayerHit, EnemyDeath, FindKey, UseKey, PowerUp;
    //backgrond music
    public AudioSource MenuMusic, WinMusic, DeathMusic, Walking, Sprinting;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        
    }

    public void PlayAudio(AudioSource oneShot)
    {
        oneShot.Play();
    }

    public void StopAudio(AudioSource oneShot)
    {
        oneShot.Stop();
    }

    public void SwordSwingSound()
    {
        SwordSwing.Play();
    }

    public void WeaponEquipSound()
    {
        WeaponEquip.Play();
    }
    public void CriticalHitSound()
    {
        CriticalHit.Play();
    }
    public void EnemyHitSound()
    {
        EnemyHit.Play();
    }
    public void PlayerHitSound()
    {
        PlayerHit.Play();
    }
    public void EnemyDeathSound()
    {
        EnemyDeath.Play();
    }
    public void UseKeySound()
    {
        UseKey.Play();
    }
    public void PowerUpSound()
    {
        PowerUp.Play();
    }

}
