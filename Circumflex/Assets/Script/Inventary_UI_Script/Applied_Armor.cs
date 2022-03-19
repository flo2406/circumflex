using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Applied_Armor : MonoBehaviour
{
    private Type type;
    
    private int stat_vitality;
    private int stat_wisdom;
    private int stat_strength;
    private int stat_defense;
    private int stat_speed;
    private int rarity;

    [SerializeField] private Image color;
    [SerializeField] private GameObject description;
    [SerializeField] private GameObject ui;

    private GameObject description_ui;
    private GameObject competences_ui;

    void Start()
    {
        stat_vitality = 0;
        stat_wisdom = 0;
        stat_strength = 0;
        stat_defense = 0;
        stat_speed = 0;
        rarity = -1;
        change_color();

        Transform[] children = ui.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.tag == "Description_ui")
                description_ui = child.gameObject;
            if (child.tag == "Competences_ui")
                competences_ui = child.gameObject;
        }
    }

    void change_color()
    {
        if (rarity == -1)
            color.color = Color.white;
        if(rarity == 0)
            color.color = Color.grey;
        if (rarity == 1)
            color.color = Color.blue;
        if (rarity == 2)
            color.color = Color.red;
        if (rarity == 3)
            color.color = Color.yellow;
    }

    public void set_stat(int vitality, int wisdom, int strength, int defense, int speed, int rare, Type type)
    {
        stat_vitality += vitality;
        competences_ui.GetComponentInChildren<Vitality>().set_vitality_armor(vitality);

        stat_wisdom += wisdom;
        competences_ui.GetComponentInChildren<Wisdom>().set_wisdom_armor(wisdom);

        stat_strength += strength;
        competences_ui.GetComponentInChildren<Strength>().set_strength_armor(strength);

        stat_defense += defense;
        competences_ui.GetComponentInChildren<Defense>().set_defense_armor(defense);

        stat_speed += speed;
        competences_ui.GetComponentInChildren<Speed>().set_speed_armor(speed);

        rarity = rare;
        change_color();

        this.type = type;
    }

    public void On_Click_Item()
    {
        GameObject actual_description = ui.GetComponent<Description>().get_description();
        if (actual_description != null)
        {
            Destroy(actual_description);
            ui.GetComponent<Description>().set_description(null);
        }

        GameObject newDescription = Instantiate(description, description_ui.transform);
        ui.GetComponent<Description>().set_description(newDescription);
    }

    public int get_vit()
    {
        return stat_vitality;
    }

    public int get_wis()
    {
        return stat_wisdom;
    }

    public int get_str()
    {
        return stat_strength;
    }

    public int get_def()
    {
        return stat_defense;
    }

    public int get_spe()
    {
        return stat_speed;
    }

}
