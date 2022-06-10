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

    public bool use_mana(float use)
    {
        if (use > mana)
            return false;
        
        mana -= use;
        return true;
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
        health += 0.2f * health_max;
        if(health > health_max)
            health = health_max;
    }

    public void mana_potion()
    {
        mana += 0.2f * mana_max;
        if (mana > mana_max)
            mana = mana_max;
    }


    public float get_mana()
    {
        return mana;
    }

    void Update()
    {
        mana += 0.05f;
        
        if(mana > mana_max)
            mana = mana_max;

        health_barre.fillAmount = health / health_max;
        mana_barre.fillAmount = mana / mana_max;
    }
}
