using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    private string perso_name;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }


    public void set_and_write_Name(string nom)
    {
        perso_name = nom;
        text.text = nom;
    }
}
