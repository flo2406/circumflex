using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Dammage : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ennemi")
        {
            AI ai = other.gameObject.GetComponent<AI>();
            if (ai != null)
                ai.take_dammages(50);
        }
    }
}
