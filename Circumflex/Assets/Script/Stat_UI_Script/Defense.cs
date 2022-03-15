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

    void Start()
    {
        text = GetComponent<Text>();
        defense_competence = 20;
        defense_armor = 0;
        To_Str();
    }

    void To_Str()
    {
        text.text = "Defense :   " + defense_competence + "  (";
        if (defense_armor >= 0)
            text.text += "+";
        text.text += defense_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        defense_competence += 1;
        To_Str();
    }
}
