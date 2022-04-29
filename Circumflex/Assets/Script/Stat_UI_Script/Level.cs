using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int level;
    private Stats stats;
    private Text text;

    void Start()
    {
        stats = GameObject.FindWithTag("stat").GetComponent<Stats>();
        text = GetComponent<Text>();
        text.text = "Level " + stats.get_level();
    }
}
