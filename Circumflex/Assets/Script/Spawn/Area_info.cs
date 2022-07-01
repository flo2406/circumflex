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
        if(area != 3)
            area = i;

        Text txt = GameObject.FindGameObjectWithTag("info_zone").GetComponent<Text>();
        if (area != 3)
            txt.text = "Zone : " + area;
        else
            txt.text = "Zone : 3 (Boss)";

        Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
        spawn.change_zone(area);
    }

    public int get_area()
    {
        return area;
    }
}
