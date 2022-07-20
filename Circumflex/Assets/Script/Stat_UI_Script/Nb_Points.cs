using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nb_Points : MonoBehaviour
{
    private Text text;
    private int nb_points;

    [SerializeField] private Button button_vitality;
    [SerializeField] private Button button_wisdom;
    [SerializeField] private Button button_strength;
    [SerializeField] private Button button_defense;
    [SerializeField] private Button button_speed;
    private List<Button> arr_button;

    void Start()
    {
        text = GetComponent<Text>();
        nb_points = 1;
        text.text = "Points capital : 1";
        arr_button = new List<Button>();
        arr_button.Add(button_vitality);
        arr_button.Add(button_wisdom);
        arr_button.Add(button_strength);
        arr_button.Add(button_defense);
        arr_button.Add(button_speed);
    }

    public int get_nb_points()
    {
        return nb_points;
    }

    public void add_nb_points(int add)
    {
        if (nb_points == 0)
            make_button_enable();
        nb_points += add;
        text.text = "Points capital : " + nb_points;
    }

    public void use_points()
    {
        nb_points--;
        text.text = "Points capital : " + nb_points;
        if (nb_points == 0)
            make_button_disable();
    }

    public void make_button_disable()
    {
        foreach(Button button in arr_button)
        {
            button.enabled = false;
        }
    }
    public void make_button_enable()
    {
        foreach (Button button in arr_button)
        {
            button.enabled = true;
        }
    }

}
