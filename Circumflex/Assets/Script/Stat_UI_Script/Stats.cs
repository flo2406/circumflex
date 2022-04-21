using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int vitality;
    private int wisdom;
    private int strength;
    private int defense;
    private int speed;

    void Start()
    {
        vitality = 100;
        wisdom = 20;
        strength = 20;
        defense = 20;
        speed = 20;
    }

    public int get_vitality()
    {
        return vitality;
    }

    public int get_wisdom()
    {
        return wisdom;
    }

    public int get_strength()
    {
        return strength;
    }

    public int get_defense()
    {
        return defense;
    }

    public int get_speed()
    {
        return speed;
    }




    public void set_vitality(int vit)
    {
        vitality = vit;
    }

    public void set_wisdom(int wis)
    {
        wisdom = wis;
    }

    public void set_strength(int str)
    {
        strength = str;
    }

    public void set_defense(int def)
    {
        defense = def;
    }

    public void set_speed(int spe)
    {
        speed = spe;
    }

}
