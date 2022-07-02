using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawn : MonoBehaviour
{
    private float time; 
    [SerializeField] private GameObject player;


    [SerializeField] private GameObject zombie_ennemy;
    [SerializeField] private GameObject archery_ennemy;
    [SerializeField] private GameObject mutant_enemy;
    private List<GameObject> different_ennemis;

    private int number_of_ennemis;
    private int max_ennemis;

    private float spawn_time;

    private int zone;

    void Start()
    {
        time = Time.time;
        spawn_time = 0.2f;
        
        number_of_ennemis = 0;
        max_ennemis = 5;

        different_ennemis = new List<GameObject>();
    }

    void Update()
    {
        if(zone == 1 || zone == 2 || zone == 4 || zone == 5)
            Instance();
    }


    public void change_zone(int new_zone)
    {
        zone = new_zone;
        if(zone == 1)
        {
            different_ennemis.Clear();
            different_ennemis.Add(zombie_ennemy);
            max_ennemis = 5;
            spawn_time = 1f;
        }

        if (zone == 2)
        {
            different_ennemis.Add(archery_ennemy);
            max_ennemis = 15;
            spawn_time = 0.9f;
        }

        if(zone == 3)
        {
            different_ennemis.Clear();
            max_ennemis = 0;
        }

        if(zone == 4)
        {
            different_ennemis.Clear();
            different_ennemis.Add(mutant_enemy);
            max_ennemis = 25;
            spawn_time = 0.7f;
        }

        if(zone == 5)
        {
            different_ennemis.Add(archery_ennemy);
            max_ennemis = 40;
            spawn_time = 0.7f;
        }

        if(zone == 6)
        {
            different_ennemis.Clear();
            max_ennemis = 0;
        }

    }

    private void Instance()
    {
        if (time + spawn_time < Time.time && number_of_ennemis < max_ennemis)
        {
            Vector3 middle = player.transform.position;
            Random random = new Random();
            int x_diff = random.Next(0, 40);
            int z_diff = random.Next(20,40) - x_diff;

            int x_sign = random.Next(0, 2) % 2;
            int z_sign = random.Next(0, 2) % 2;

            if (x_sign != 0)
                x_diff = -x_diff;

            if (z_sign != 0)
                z_diff = -z_diff;

            GameObject ennemy = different_ennemis[random.Next(different_ennemis.Count)];
            Instantiate(ennemy, new Vector3(x_diff + middle.x, 2, z_diff + middle.z), Quaternion.identity);

            time = Time.time;
            number_of_ennemis++;
        }
    }

    public void decrease_monster_number()
    {
        number_of_ennemis--;
    }

    public void increase_monster_number()
    {
        number_of_ennemis++;
    }
}
