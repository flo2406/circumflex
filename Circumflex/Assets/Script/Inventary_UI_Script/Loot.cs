using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
    private int vitality;
    private int wisdom;
    private int strength;
    private int defense;
    private int speed;
    private int rarety;

    private Type type;

    private GameObject ui;

    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("Inventary_Data");

        Area_info info = GameObject.FindGameObjectWithTag("area_info").GetComponent<Area_info>();
        int area = info.get_area();

        Random r = new Random();
        rarety = r.Next(4);

        vitality = (rarety + area) * 10  + r.Next(area * 15);
        wisdom = (rarety + area) * 10 + r.Next(area * 15);
        strength = (rarety + area) * 2 + r.Next(area * 5);
        defense = (rarety + area) * 2 + r.Next(area * 5);
        speed = (rarety + area);

        type = (Type) r.Next(2,8);

        int supp = r.Next(5);

        if (supp == 0)
            vitality = 0;

        if (supp == 1)
            wisdom = 0;

        if (supp == 2)
            strength = 0;

        if (supp == 3)
            defense = 0;

        if (supp == 4)
            speed = 0;
    }

    public void add_in_inventory()
    {
        foreach (GameObject item in ui.GetComponent<List_Inventary>().inventary)
        {
            if (item.GetComponent<Stat_Armor>().type == Type.NONE)
            {
                item.GetComponent<Image>().color = Color.yellow;
                item.GetComponent<Stat_Armor>().set_stat(vitality, wisdom, strength, defense, speed, rarety, type);
                break;
            }
        }
    }
}
