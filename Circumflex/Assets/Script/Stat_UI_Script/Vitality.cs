using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitality : MonoBehaviour
{
    private Text text;
    private int vitality_competence;
    private int vitality_armor;
    [SerializeField] private Nb_Points nb_Points;
    private Gestion_Barre gestion_Barre;

    void Start()
    {
        text = GetComponent<Text>();
        vitality_competence = 100;
        vitality_armor = 0;
        To_Str();

        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    void To_Str()
    {
        text.text = "Vitality :   " + vitality_competence + "  (";
        if (vitality_armor >= 0)
            text.text += "+";
        text.text += vitality_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        vitality_competence += 50;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(vitality_armor + vitality_competence);

        gestion_Barre.set_health(vitality_armor + vitality_competence);
    }

    public void set_vitality_armor(int vit)
    {
        vitality_armor += vit;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(vitality_armor + vitality_competence);

        gestion_Barre.set_health(vitality_armor + vitality_competence);
    }

}
