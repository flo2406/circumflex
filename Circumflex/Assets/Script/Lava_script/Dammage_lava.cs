using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammage_lava : MonoBehaviour
{
    private Gestion_Barre gestion_Barre;

    void Start()
    {
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
            gestion_Barre.make_damages(1);
    }
}
