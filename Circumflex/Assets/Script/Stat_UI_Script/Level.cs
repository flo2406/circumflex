using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int level;
    private Text text;

    void Start()
    {
        level = 1;
        text = GetComponent<Text>();
        text.text = "Level 1";
    }

    public void level_up()
    {
        level++;
        text.text = "Level " + level;
    }


}
