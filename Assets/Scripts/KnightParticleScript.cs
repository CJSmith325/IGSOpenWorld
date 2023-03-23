using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightParticleScript : MonoBehaviour
{
    public float lifespan = 0f;

    // Update is called once per frame
    void Update()
    {
        lifespan += Time.deltaTime;
        if (lifespan >= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
