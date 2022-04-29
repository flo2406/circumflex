using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int level;
    private Stats stats;
    private Text text;
    [SerializeField] private Nb_Points points;

    void Start()
    {
        level = 1;
        stats = GameObject.FindWithTag("stat").GetComponent<Stats>();
        text = GetComponent<Text>();
        text.text = "Level 1";
    }

    void Update()
    {
        text.text = "Level " + stats.get_level();
        int diff = stats.get_level() - level;
        points.add_nb_points(diff * 10);
        level = stats.get_level();
    }
}