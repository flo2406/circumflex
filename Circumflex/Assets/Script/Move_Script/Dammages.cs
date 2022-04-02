using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammages : MonoBehaviour
{
    private float begin;
    private float dammage;

    void Start()
    {
        begin = Time.time;
        dammage = 50;
    }

    void Update()
    {
        if (Time.time - begin > 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            AI ai = other.gameObject.GetComponent<AI>();
            ai.make_dammages(dammage);
        }
    }
}
