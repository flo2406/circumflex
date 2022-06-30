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


        Text txt = GameObject.FindGameObjectWithTag("info_zone").GetComponent<Text>();
        txt.text = "Zone : " + area;

        Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
        spawn.change_zone(area);
    }

    public int get_area()
    {
        return area;
    }
}
