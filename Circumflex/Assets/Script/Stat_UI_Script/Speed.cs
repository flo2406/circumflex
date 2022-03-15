using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    private Text text;
    private int speed_competence;
    private int speed_armor;
    [SerializeField] private Nb_Points nb_Points;

    void Start()
    {
        text = GetComponent<Text>();
        speed_competence = 20;
        speed_armor = 0;
        To_Str();
    }

    void To_Str()
    {
        text.text = "Wisdom :   " + speed_competence + "  (";
        if (speed_armor >= 0)
            text.text += "+";
        text.text += speed_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        speed_competence += 1;
        To_Str();
    }
}
