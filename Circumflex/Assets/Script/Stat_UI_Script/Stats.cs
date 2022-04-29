using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private int vitality;
    private int wisdom;
    private int strength;
    private int defense;
    private int speed;

    private int experience;
    private int level;
    private int[] xp_need;

    [SerializeField] private Image experience_image;

    void Start()
    {
        vitality = 100;
        wisdom = 20;
        strength = 20;
        defense = 20;
        speed = 20;

        experience = 0;
        level = 0;
        xp_need = set_experience_tab();

        experience_image.fillAmount = 0;   
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


    public void gain_experience(int xp)
    {
        experience += xp;

        if(experience >= xp_need[level])
        {
            experience -= xp_need[level];
            level++;
            GameObject.FindGameObjectWithTag("level").GetComponent<Text>().text = "" + (level + 1);
        }

        experience_image.fillAmount = (float) experience / (float) xp_need[level];
    }


    private int[] set_experience_tab()
    {
        int[] tab = new int[49];

        for(int i = 1; i < 50; i++)
        {
            float val = 1f + (i * 15f / 50f);
            tab[i - 1] = (int) (val * Mathf.Log10(val) * 10000);
        }

        return tab;
    }

    public int get_level()
    {
        return level + 1;
    }

}
