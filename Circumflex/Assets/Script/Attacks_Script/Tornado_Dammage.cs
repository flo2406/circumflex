﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Dammage : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ennemi")
        {
            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            float dammage = stat.get_strength() / 10;

            AI ai = other.gameObject.GetComponent<AI>();
            if (ai != null)
                ai.take_dammages(dammage);
        }
    }
}
