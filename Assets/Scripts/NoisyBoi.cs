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

}
