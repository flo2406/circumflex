using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_advance : MonoBehaviour
{
    private KeyCode keyCode_advance;
    private KeyCode keyCode_back;

    private int i;
    [SerializeField] private GameObject image1;
    [SerializeField] private GameObject image2;
    [SerializeField] private GameObject image3;
    [SerializeField] private GameObject image4;
    [SerializeField] private GameObject image5;
    [SerializeField] private GameObject image6;
    GameObject[] tab;

    void Start()
    {
        keyCode_advance = KeyCode.RightArrow;
        keyCode_back = KeyCode.LeftArrow;

        i = 0;
        tab = new GameObject[6];
        tab[0] = image1;
        tab[1] = image2;
        tab[2] = image3;
        tab[3] = image4;
        tab[4] = image5;
        tab[5] = image6;
    }

    // Update is called once per frame
    void Update()
    {
        if(i > 0 && Input.GetKeyDown(keyCode_back))
        {
            tab[i].SetActive(false); 
            i--;
            tab[i].SetActive(true);
        }
        else if(i < 5 && Input.GetKeyDown(keyCode_advance))
        {
            tab[i].SetActive(false);
            i++;
            tab[i].SetActive(true);
        }


    }
}
