using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightParticleScript : MonoBehaviour
{
    public float lifespan = 0f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
    }

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
