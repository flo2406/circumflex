using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammages : MonoBehaviour
{
    [SerializeField] private GameObject loot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            Destroy(other.gameObject);
            Instantiate(loot,transform.position,transform.rotation);
        }
    }
}
