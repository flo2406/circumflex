using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammages : MonoBehaviour
{
    [SerializeField] private GameObject loot;
    private float begin;

    void Start()
    {
        begin = Time.time;
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
            Destroy(other.gameObject);
            Instantiate(loot,transform.position,transform.rotation);
        }
    }
}
