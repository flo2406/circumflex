﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawn : MonoBehaviour
{
    private float time; 
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mutant_ennemy;
    private int number_of_ennemis;
    private int max_ennemis;

    private float spawn_time;

    private int zone;

    void Start()
    {
        time = Time.time;
        spawn_time = 0.2f;
        
        number_of_ennemis = 0;
        max_ennemis = 10;
    }

    void Update()
    {
        Instance();
    }


    public void change_zone(int new_zone)
    {
        zone = new_zone;
        if(zone == 1)
        {
            max_ennemis = 10;
            spawn_time = 0.2f;
        }

        if (zone == 2)
        {
            max_ennemis = 50;
            spawn_time = 0.1f;
        }

        if (zone == 3)
        {
            max_ennemis = 150;
            spawn_time = 0.05f;
        }
    }

    private void Instance()
    {
        if (time + spawn_time < Time.time && number_of_ennemis < max_ennemis)
        {
            Vector3 middle = player.transform.position;
            Random random = new Random();
            int x_diff = random.Next(0, 100);
            int z_diff = random.Next(50,100) - x_diff;

            int x_sign = random.Next(0, 2) % 2;
            int z_sign = random.Next(0, 2) % 2;

            if (x_sign != 0)
                x_diff = -x_diff;

            if (z_sign != 0)
                z_diff = -z_diff;

            Instantiate(mutant_ennemy, new Vector3(x_diff + middle.x, 10, z_diff + middle.z), Quaternion.identity);

            time = Time.time;
            number_of_ennemis++;
            
        }
    }

    public void decrease_monster_number()
    {
        Debug.Log("-1");
        number_of_ennemis--;
    }
}