using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Defense : MonoBehaviour
{
    private Text text;
    private int defense_competence;
    private int defense_armor;
    [SerializeField] private Nb_Points nb_Points;

    private Gestion_Barre gestion_Barre;

    void Start()
    {
        text = GetComponent<Text>();
        defense_competence = 100;
        defense_armor = 0;
        To_Str();

        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    void To_Str()
    {
        text.text = "Mana :   " + defense_competence + "  (";
        if (defense_armor >= 0)
            text.text += "+";
        text.text += defense_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        defense_competence += 20;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_defense(defense_armor + defense_competence);

        gestion_Barre.set_mana(defense_armor + defense_competence);
    }

    public void set_defense_armor(int def)
    {
        defense_armor += def;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_defense(defense_armor + defense_competence);

        gestion_Barre.set_mana(defense_armor + defense_competence);
    }
}
