using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Storage : MonoBehaviour
{
    private Type type;

    private int stat_vitality;
    private int stat_wisdom;
    private int stat_strength;
    private int stat_defense;
    private int stat_speed;
    private int rarity;

    private GameObject ui;
    private GameObject armor_ui;

    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
        Transform[] children = ui.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Armor_UI")
                armor_ui = child.gameObject;
        }
    }

    public void set_stat(int vitality, int wisdom, int strength, int defense, int speed, int rare, Type type)
    {
        stat_vitality = vitality;
        stat_wisdom = wisdom;
        stat_strength = strength;
        stat_defense = defense;
        stat_speed = speed;
        rarity = rare;
        this.type = type;
    }

    public void On_click_use()
    {
        Transform[] children = armor_ui.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Sword" && type == Type.SWORD)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);

            else if (child.name == "Shield" && type == Type.SHIELD)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);

            else if (child.name == "Belt" && type == Type.BELT)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);

            else if (child.name == "Ring" && type == Type.RING)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);

            else if (child.name == "Amulet" && type == Type.AMULET)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);

            else if (child.name == "Helmet" && type == Type.HELMET)
                child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom, stat_strength, stat_defense, stat_speed, rarity, type);
        }
    }
}
