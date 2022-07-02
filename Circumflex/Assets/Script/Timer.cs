using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int malus;

    void Start()
    {
        malus = 0;
    }

    void Update()
    {
        int time = (int)Time.time + malus;
        int min = time / 60;
        int sec = time - min * 60;
        string text;
        if (sec < 10)
            text = Convert.ToString(min) + " : " + "0" + Convert.ToString(sec);
        else
            text = Convert.ToString(min) + " : " + Convert.ToString(sec);
        gameObject.GetComponent<Text>().text = text;
    }

    public void add_mulus()
    {
        malus+= 60;
    }

}
