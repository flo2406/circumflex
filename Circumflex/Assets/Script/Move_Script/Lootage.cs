using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootage : MonoBehaviour
{
    [SerializeField] private GameObject ennemy;

    void Start()
    {
        Instantiate(ennemy);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ennemy(Clone)")
        {
            if (Input.GetKey(KeyCode.A))
            {
                other.gameObject.GetComponent<Loot>().add_in_inventory();
                Destroy(other.gameObject);
            }
        }
    }
}
