using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrical_laser : MonoBehaviour
{
    [SerializeField] GameObject attack;
    private int forceForward;
    private KeyCode keyCode;

    private bool have_to_send;
    private Gestion_Barre gestion_Barre;

    void Start()
    {
        forceForward = 1000;
        keyCode = KeyCode.R;

        have_to_send = false;
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    void Update()
    {
        bool shield = GetComponent<Active_Shield>().have_shield();

        if (Input.GetKeyDown(keyCode) && !shield)
        {
            gestion_Barre.use_mana(5f);
            have_to_send = true;
        }

        if (Input.GetKeyUp(keyCode) || shield)
            have_to_send = false;

        if (have_to_send)
        {
            bool res = gestion_Barre.use_mana(0.2f);
            if(!res)
            {
                have_to_send = false;
                return;
            }

            GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
            clone.GetComponent<Dammages>().set_type_of_attack("electrical");
            Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
            clone.GetComponent<Rigidbody>().AddForce(val);
        }


    }
}
