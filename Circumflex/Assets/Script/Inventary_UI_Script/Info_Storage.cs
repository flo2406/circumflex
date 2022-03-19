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
                set_stat(child);

            else if (child.name == "Shield" && type == Type.SHIELD)
                set_stat(child);

            else if (child.name == "Belt" && type == Type.BELT)
                set_stat(child);

            else if (child.name == "Ring" && type == Type.RING)
                set_stat(child);

            else if (child.name == "Amulet" && type == Type.AMULET)
                set_stat(child);

            else if (child.name == "Helmet" && type == Type.HELMET)
                set_stat(child);

        }
    }

    void set_stat(Transform child)
    {
        int removeVit = child.gameObject.GetComponent<Applied_Armor>().get_vit();
        int removeWis = child.gameObject.GetComponent<Applied_Armor>().get_wis();
        int removeStr = child.gameObject.GetComponent<Applied_Armor>().get_str();
        int removeDef = child.gameObject.GetComponent<Applied_Armor>().get_def();
        int removeSpe = child.gameObject.GetComponent<Applied_Armor>().get_spe();

        child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality - removeVit,
                    stat_wisdom - removeWis, stat_strength - removeStr, stat_defense - removeDef,
                    stat_speed - removeSpe, rarity, type);
    }
}
