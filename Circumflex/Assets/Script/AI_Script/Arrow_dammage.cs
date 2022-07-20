using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_dammage : MonoBehaviour
{
    private GameObject player;
    private Gestion_Barre gestion_Barre;
    private float timer;
    private float max_time;
    private int clear_anim;
    private int dammages;

    private void Start()
    {
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
        timer = Time.time;
        max_time = 5f;
        clear_anim = 0;
        player = null;
    }

    private void Update()
    {
        if (clear_anim == 1)
            clear_anim++;

        else if (clear_anim == 2)
        {
            Destroy(gameObject);
            player.GetComponent<Animations>().clear_hit_anim();
        }
        else if (timer + max_time < Time.time)
            Destroy(gameObject);
    }

    public void set_dammages(int _dammages)
    {
        dammages = _dammages;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;

            bool shield = player.GetComponentInChildren<Active_Shield>().have_shield();

            if (!shield)
            {
                player.GetComponent<Animations>().set_hit_anim();
                clear_anim = 1;

                GameObject stat = GameObject.FindWithTag("stat");
                float dammage = dammages / 20;
                gestion_Barre.make_damages(dammage);
            }
        }
    }
}
