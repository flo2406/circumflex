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
    public Type type;
    private int stat_vitality;
    private int stat_wisdom;
    private int stat_strength;
    private int stat_defense;
    private int stat_speed;

    [SerializeField] private GameObject description;
    private GameObject ui;

    void Start()
    {
        type = Type.POTION;
        stat_vitality = 0;
        stat_wisdom = 0;
        stat_strength = 0;
        stat_defense = 0;
        stat_speed = 0;
    }

    public void On_Click_Item()
    {
        GameObject actual_description = ui.GetComponent<Description>().get_description();
        if(actual_description != null)
        {
            Destroy(actual_description);
            ui.GetComponent<Description>().set_description(null);
        }

        Transform parent = null;
        if(type != Type.NONE)
        {
            Transform[] children = ui.GetComponentsInChildren<Transform>();
            foreach(Transform child in children)
            {

                if (child.tag == "Description_ui")
                    parent = child;
            }

            GameObject newDescription = Instantiate(description,parent);
            ui.GetComponent<Description>().set_description(newDescription);
        }
    }

    public void set_ui(GameObject new_ui)
    {
        ui = new_ui;
    }
}
