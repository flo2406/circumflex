using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area_info : MonoBehaviour
{
    private int area;

    void Start()
    {
        area = 1;
    }

    public void set_area(int i)
    {
        area = i;

        Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
        spawn.change_zone(area);
        spawn.make_text_info_zone();
    }

    public void kill_reset_area()
    {
        if (area < 4)
            area = 1;
        else
            area = 4;

        Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
        spawn.change_zone(area);
        spawn.make_text_info_zone();
    }

    public int get_area()
    {
        return area;
    }
}
