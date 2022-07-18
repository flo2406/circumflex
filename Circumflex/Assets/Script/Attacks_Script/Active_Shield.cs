using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private KeyCode keyCode;
    private bool actif;
    private Gestion_Barre gestion_Barre;

    void Start()
    {
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
        actif = false;
        shield.SetActive(false);
        //keyCode = KeyCode.Z;
        keyCode = KeyCode.W;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            actif = !actif;
            shield.SetActive(!shield.activeSelf);
        }

        /*if (actif)
        {
            bool res = gestion_Barre.use_mana(0.1f);
            if(!res)
            {
                actif = !actif;
                shield.SetActive(!shield.activeSelf);
            }
        }*/
    }

    public bool have_shield()
    {
        return actif;
    }

}
