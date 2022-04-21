using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wisdom : MonoBehaviour
{
    private Text text;
    private int wisdom_competence;
    private int wisdom_armor;
    [SerializeField] private Nb_Points nb_Points;

    void Start()
    {
        text = GetComponent<Text>();
        wisdom_competence = 20;
        wisdom_armor = 0;
        To_Str();
    }

    void To_Str()
    {
        text.text = "Wisdom :   " + wisdom_competence + "  (";
        if (wisdom_armor >= 0)
            text.text += "+";
        text.text += wisdom_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        wisdom_competence += 1;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(wisdom_armor + wisdom_competence);
    }

    public void set_wisdom_armor(int wis)
    {
        wisdom_armor += wis;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_vitality(wisdom_armor + wisdom_competence);
    }
}
