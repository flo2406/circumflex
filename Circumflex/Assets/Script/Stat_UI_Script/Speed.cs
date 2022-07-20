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
        text.text = "Speed :   " + speed_competence + "  (";
        if (speed_armor >= 0)
            text.text += "+";
        text.text += speed_armor + ")";
    }

    public void On_Click_Button()
    {
        nb_Points.use_points();
        speed_competence += 10;
        To_Str();

        GameObject stat = GameObject.FindWithTag("stat");
        stat.GetComponent<Stats>().set_speed(speed_armor + speed_competence);
    }
    public void set_speed_armor(int spe)
    {
        speed_armor += spe;
        To_Str();
    }

}
