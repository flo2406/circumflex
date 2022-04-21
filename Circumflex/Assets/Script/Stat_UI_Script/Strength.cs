using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strength : MonoBehaviour
{
    private Text text;
    private int strength_competence;
    private int strength_armor;
    [SerializeField] private Nb_Points nb_Points;

    void Start()
    {
        text = GetComponent<Text>();
        strength_competence = 20;
        strength_armor = 0;
        To_Str();
    }

    void To_Str()
    {
        text.text = "Strength :   " + strength_competence + "  (";
        if (strength_armor >= 0)
            text.text += "+";
        text.text += strength_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        strength_competence += 1;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(strength_armor + strength_competence);
    }

    public void set_strength_armor(int str)
    {
        strength_armor += str;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(strength_armor + strength_competence);
    }
}
