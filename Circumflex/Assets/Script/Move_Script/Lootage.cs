using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootage : MonoBehaviour
{
    [SerializeField] private GameObject ennemy;
    [SerializeField] private Material mat;
    [SerializeField] private Material basicMat;

    void Start()
    {
        Instantiate(ennemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ennemy(Clone)")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = basicMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ennemy(Clone)")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = mat;
            if (Input.GetKey(KeyCode.A))
            {
                other.gameObject.GetComponent<Loot>().add_in_inventory();
                Destroy(other.gameObject);
                Instantiate(ennemy);
            }
        }
    }
}
