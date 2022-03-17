using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    NONE,
    POTION,
    SWORD,
    SHIELD,
    RING,
    BOOTS,
    BELT,
    AMULET,
}

public class Stat_Armor : MonoBehaviour
{
    private Type type;
    private int stat_vitality;
    private int stat_wisdom;
    private int stat_strength;
    private int stat_defense;
    private int stat_speed;


    [SerializeField] private GameObject description;
    [SerializeField] private Transform description_zone;
    private GameObject actual_description;

    void Start()
    {
        type = Type.NONE;
        stat_vitality = 0;
        stat_wisdom = 0;
        stat_strength = 0;
        stat_defense = 0;
        stat_speed = 0;

        actual_description = null;
    }

    public void On_Click_Item()
    {
        if(actual_description != null)
        {
            Destroy(actual_description);
        }

        if(type != Type.NONE)
        {
            GameObject newDescription = Instantiate(description, description_zone);
            actual_description = newDescription;
        }
    }
}
