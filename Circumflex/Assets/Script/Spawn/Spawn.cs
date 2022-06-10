using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawn : MonoBehaviour
{
    private float time; 
    [SerializeField] private GameObject player;


    [SerializeField] private GameObject mutant_ennemy;
    [SerializeField] private GameObject archery_ennemy;
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
        different_ennemis.Add(mutant_ennemy);
        different_ennemis.Add(archery_ennemy);
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
            max_ennemis = 5;
            spawn_time = 1f;
        }

        if (zone == 2)
        {
            max_ennemis = 20;
            spawn_time = 0.5f;
        }

        if (zone == 3)
        {
            max_ennemis = 50;
            spawn_time = 0.3f;
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

            GameObject ennemy = different_ennemis[random.Next(0, zone)];
            Instantiate(ennemy, new Vector3(x_diff + middle.x, 2, z_diff + middle.z), Quaternion.identity);

            time = Time.time;
            number_of_ennemis++;
            
        }
    }

    public void decrease_monster_number()
    {
        number_of_ennemis--;
    }
}
