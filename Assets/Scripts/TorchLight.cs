using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    Light lt;
    public float lightChange;

    // Start is called before the first frame update
    void Start()
    {
        lt = gameObject.GetComponent<Light>();
        InvokeRepeating("ChangeColor", 10f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        float rand = Random.Range(0f, 1f);

        if(rand > lightChange)
        {
            lt.color = new Color(255f, Random.Range(100f, 255f), 0f);

        }

    }
}
