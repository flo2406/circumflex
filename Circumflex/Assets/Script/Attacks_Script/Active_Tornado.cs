using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Tornado : MonoBehaviour
{
    [SerializeField] private GameObject tornado;
    private KeyCode keyCode;
    private bool active;
    private Gestion_Barre gestion_Barre;


    void Start()
    {
        active = false;
        tornado.SetActive(false);
        keyCode = KeyCode.E;
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (!active)
            {
                gameObject.GetComponentInParent<Animations>().set_tornado_anim();
                tornado.SetActive(true);
                active = true;
            }
            else
            {
                gameObject.GetComponentInParent<Animations>().clear_tornado_anim();
                tornado.SetActive(false);
                active = false;
            }
        }

        if(active)
        {
            bool res = gestion_Barre.use_mana(0.1f);
            if(!res)
            {
                gameObject.GetComponentInParent<Animations>().clear_tornado_anim();
                tornado.SetActive(false);
                active = false;
            }
        }
    }
}