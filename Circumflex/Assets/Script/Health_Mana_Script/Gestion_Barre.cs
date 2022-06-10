using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestion_Barre : MonoBehaviour
{
    private float health;
    private float health_max;
    
    private float mana;
    private float mana_max;

    [SerializeField] private Image health_barre;
    [SerializeField] private Image mana_barre;

    void Start()
    {
        health = 100f;
        health_max = 100f;
        
        mana = 10f;
        mana_max = 100f;
    }

    public void make_damages(float dammages)
    {
        health -= dammages;
        if(health < 0)
            health = 0;
    }

    public void use_mana(float use)
    {
        mana -= use;
    }

    public float get_health()
    {
        return health;
    }

    public void set_health(float new_health)
    {
        int percent = (int) (health * new_health / health_max);
        health_max = new_health;
        health = percent;
    }

    public void health_potion()
    {
        health += 20;
        if(health > 100)
            health = 100;
    }

    public void mana_potion()
    {
        mana += 20;
        if (mana > 100)
            mana = 100;
    }


    public float get_mana()
    {
        return mana;
    }

    void Update()
    {
        mana += 0.01f;
        
        if(mana > 100)
            mana = 100;

        health_barre.fillAmount = health / health_max;
        mana_barre.fillAmount = mana / mana_max;
    }
}
