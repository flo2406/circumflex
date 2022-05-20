using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammages : MonoBehaviour
{
    private float begin;
    private string type_of_attack;

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
            float dammage;
            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();

            if (type_of_attack == "fireball")
                dammage = stat.get_strength() * 2;
            else
                dammage = stat.get_strength() / 7;

            AI ai = other.gameObject.GetComponent<AI>();
            if (ai != null)
                ai.take_dammages(dammage);
           
            Archerie_AI ai_arch = other.gameObject.GetComponent<Archerie_AI>();
            if (ai_arch != null)
                ai_arch.take_dammages(dammage);
        }
    }

    public void set_type_of_attack(string str)
    {
        type_of_attack = str;
    }
}
