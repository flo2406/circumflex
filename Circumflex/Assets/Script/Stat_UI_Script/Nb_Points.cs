using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nb_Points : MonoBehaviour
{
    private Text text;
    private int nb_points;

    [SerializeField] private GameObject button_vitality;
    [SerializeField] private GameObject button_wisdom;
    [SerializeField] private GameObject button_strength;
    [SerializeField] private GameObject button_defense;
    [SerializeField] private GameObject button_speed;
    private List<GameObject> arr_button;

    private bool hide_button;

    void Start()
    {
        text = GetComponent<Text>();
        nb_points = 1;
        text.text = "Points capital : 1";
        arr_button = new List<GameObject>();
        arr_button.Add(button_vitality);
        arr_button.Add(button_wisdom);
        arr_button.Add(button_strength);
        arr_button.Add(button_defense);
        arr_button.Add(button_speed);

        hide_button = false;
    }

    void Update()
    {
        if (hide_button)
            make_button_disable();
    }

    public int get_nb_points()
    {
        return nb_points;
    }

    public void add_nb_points(int add)
    {
        if (nb_points > 0)
        {
            hide_button = false;
            make_button_enable();
        }
        nb_points += add;
        text.text = "Points capital : " + nb_points;
    }

    public void use_points()
    {
        nb_points--;
        text.text = "Points capital : " + nb_points;

        if (nb_points == 0)
            hide_button = true;
    }

    public void make_button_disable()
    {
        foreach(GameObject button in arr_button)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void make_button_enable()
    {
        foreach (GameObject button in arr_button)
        {
            button.gameObject.SetActive(true);
        }
    }


}
