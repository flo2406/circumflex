using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private GameObject item;

    void Awake()
    {
        item = null;
    }

    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
        Transform[] children = ui.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Armor_UI")
                armor_ui = child.gameObject;
        }
        make_description();
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


    public void On_click_delete()
    {
        if (item != null)
        {
            item.GetComponent<Image>().color = Color.white;
            item.GetComponent<Stat_Armor>().type = Type.NONE;
            Destroy(gameObject);
        }
    }


   Transform find_ui()
   {
        Transform[] children = armor_ui.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Sword" && type == Type.SWORD)
                return child;

            if (child.name == "Shield" && type == Type.SHIELD)
                return child;

            else if (child.name == "Belt" && type == Type.BELT)
                return child;

            else if (child.name == "Ring" && type == Type.RING)
                return child;

            else if (child.name == "Amulet" && type == Type.AMULET)
                return child;

            else if (child.name == "Helmet" && type == Type.HELMET)
                return child;
        }
        return null;
    }


    public void On_click_use()
    {
        if (item != null)
        {
            item.GetComponent<Image>().color = Color.white;
            item.GetComponent<Stat_Armor>().type = Type.NONE;
        }

        Transform child = find_ui();
        child.gameObject.GetComponent<Applied_Armor>().Restore_Item();
        child.gameObject.GetComponent<Applied_Armor>().set_stat(stat_vitality, stat_wisdom , stat_strength, stat_defense, stat_speed, rarity, type);

        Destroy(gameObject);
    }


    void make_description()
    {
        string begin = "stat_";
        int i = 1;
        if(stat_vitality > 0)
        {
            Text t = get_str(begin + i);
            t.text = "+ " + stat_vitality + " vitality";
            i++;
        }
        if (stat_wisdom > 0)
        {
            Text t = get_str(begin + i);
            t.text = "+ " + stat_wisdom + " wisdom";
            i++;
        }
        if (stat_strength > 0)
        {
            Text t = get_str(begin + i);
            t.text = "+ " + stat_strength + " strength";
            i++;
        }
        if (stat_defense > 0)
        {
            Text t = get_str(begin + i);
            t.text = "+ " + stat_defense + " defense";
            i++;
        }
        if (stat_speed > 0)
        {
            Text t = get_str(begin + i);
            t.text = "+ " + stat_speed + " speed";
            i++;
        }

        Text t2 = get_str("Name");
        
        switch(type)
        {
            case Type.SWORD:
                t2.text = "Sword";
                break;

            case Type.SHIELD:
                t2.text = "Shield";
                break;

            case Type.BELT:
                t2.text = "Belt";
                break;

            case Type.RING:
                t2.text = "Ring";
                break;

            case Type.AMULET:
                t2.text = "Amulet";
                break;

            case Type.HELMET:
                t2.text = "Helmet";
                break;

            default:
                break;

        }


    }

    Text get_str(string str)
    {
        Text[] texts = gameObject.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (text.gameObject.name == str)
                return text;
        }
        return null;
    }

    public void set_item(GameObject item)
    {
        this.item = item;
    }
}
