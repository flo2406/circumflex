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

        Random r = new Random();
        rarety = r.Next(4);

        vitality = rarety * 100 + r.Next(500);
        wisdom = rarety * 10 + r.Next(50);
        strength = rarety * 20 + r.Next(100);
        defense = rarety * 20 + r.Next(100);
        speed = rarety * 20 + r.Next(100);

        type = Type.SHIELD;

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
                Debug.Log("Adding");
                item.GetComponent<Image>().color = Color.yellow;
                item.GetComponent<Stat_Armor>().set_stat(vitality, wisdom, strength, defense, speed, rarety, type);
                break;
            }
        }
    }
}
