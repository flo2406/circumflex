using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


    // Tab for zone 1/2/4/5
    private int[] number_of_kill;
    private int[] kill_to_clear;


    [SerializeField] private GameObject side1;
    [SerializeField] private GameObject side2;
    [SerializeField] private GameObject side3;
    [SerializeField] private GameObject side4;
    [SerializeField] private GameObject side5;
    [SerializeField] private GameObject side6;
    private GameObject[] side_objects;

    private int zone_open;
    [SerializeField] private GameObject arrow;
   

    void Start()
    {
        time = Time.time;
        spawn_time = 0.2f;
        
        number_of_ennemis = 0;
        max_ennemis = 5;

        different_ennemis = new List<GameObject>();

        number_of_kill = new int[] { 0, 0, 0, 0, 0, 0 };
        kill_to_clear = new int[] { 10, 25, 0, 40, 50, 0 };
        side_objects = new GameObject[] { side1, side2, side3, side4, side5, side6 };
        
        zone_open = 1;
    }

    void Update()
    {
        if(zone == 1 || zone == 2 || zone == 4 || zone == 5)
            Instance();

        if (zone_open > zone)
            arrow.SetActive(true);
        else
            arrow.SetActive(false);
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
            different_ennemis.Clear();
            different_ennemis.Add(zombie_ennemy);
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
            different_ennemis.Clear();
            different_ennemis.Add(mutant_enemy);
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

            int var = random.Next(different_ennemis.Count);
            GameObject ennemy = different_ennemis[var];
            Instantiate(ennemy, new Vector3(x_diff + middle.x, 2, z_diff + middle.z), Quaternion.identity);

            time = Time.time;
            number_of_ennemis++;
        }
    }



    public void make_text_info_zone()
    {
        Text txt = GameObject.FindGameObjectWithTag("info_zone").GetComponent<Text>();
        if (zone != 3 && zone != 6)
        {
            txt.text = "Zone : " + zone;
            txt.text += "\n\n";
            txt.text += number_of_kill[zone - 1] + " kills / " + kill_to_clear[zone - 1];

        }
        else
            txt.text = "Zone : " + zone + " (Boss)";

    }


    public void decrease_monster_number(bool kill)
    {
        make_text_info_zone();
        if (kill)
        {
            number_of_kill[zone - 1]++;
            Debug.Log(number_of_kill[zone - 1]);
            if (kill_to_clear[zone - 1] <= number_of_kill[zone - 1] && (zone != 3 && zone != 6))
            {
                side_objects[zone - 1].SetActive(false);
                zone_open++;
            }
        }

        number_of_ennemis--;
    }

    public void increase_monster_number()
    {
        number_of_ennemis++;
    }
}
