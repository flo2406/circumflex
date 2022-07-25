using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootage : MonoBehaviour
{
    [SerializeField] private Material mat;
    //[SerializeField] private Material basicMat;

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "loot")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = basicMat;
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "loot")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = mat;
            if (Input.GetKey(KeyCode.Space))
            {
                other.gameObject.GetComponent<Loot>().add_in_inventory();
                Destroy(other.gameObject);
            }
        }
    }
}
