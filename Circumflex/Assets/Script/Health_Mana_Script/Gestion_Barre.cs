using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestion_Barre : MonoBehaviour
{
    private float health;
    private float mana;

    [SerializeField] private Image health_barre;
    [SerializeField] private Image mana_barre;

    void Start()
    {
        health = 100f;
        mana = 100f;
    }

    public void make_damages(float damages)
    {
        health -= damages;
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

    public float get_mana()
    {
        return mana;
    }

    void Update()
    {
        mana += 0.01f;
        
        if(mana > 100)
            mana = 100;

        health_barre.fillAmount = health / 100;
        mana_barre.fillAmount = mana / 100;
    }
}
