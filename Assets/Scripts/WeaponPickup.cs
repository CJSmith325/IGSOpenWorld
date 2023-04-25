using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public int weapon;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            WeaponSwitch.Instance.unlocked[weapon] = true;
            WeaponSwitch.Instance.unlocked[weapon - 1] = false;

            if(weapon % 3 == 2)
                WeaponSwitch.Instance.unlocked[weapon - 2] = false;

            Destroy(gameObject);

        }
    }

}
