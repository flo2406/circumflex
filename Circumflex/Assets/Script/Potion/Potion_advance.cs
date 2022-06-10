using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_advance : MonoBehaviour
{
    private KeyCode keyCode_use;

    private int i;
    private int nb_kill;

    private int type_of_potion;

    //Potion 0 : Health
    //Potion 1 : Mana
    //Potion 2 : Strength
    //Potion 3 : Defense
    
    [SerializeField] private GameObject image1;
    [SerializeField] private GameObject image2;
    [SerializeField] private GameObject image3;
    [SerializeField] private GameObject image4;
    [SerializeField] private GameObject image5;
    [SerializeField] private GameObject image6;
    GameObject[] tab;


    private void associate_potion()
    {
        if (gameObject.name == "Evolution_potion_health")
        {
            type_of_potion = 0;
            keyCode_use = KeyCode.Alpha1;
        }
        else if (gameObject.name == "Evolution_potion_mana")
        {
            type_of_potion = 1;
            keyCode_use = KeyCode.Alpha2;
        }
        else if (gameObject.name == "Evolution_potion_strength")
        {
            type_of_potion = 2;
            keyCode_use = KeyCode.Alpha3;
        }
        else
        {
            type_of_potion = 3;
            keyCode_use = KeyCode.Alpha4;
        }
    }


    void Start()
    {
        associate_potion();

        i = 5;
        tab = new GameObject[6];
        tab[0] = image1;
        tab[1] = image2;
        tab[2] = image3;
        tab[3] = image4;
        tab[4] = image5;
        tab[5] = image6;
        tab[0].SetActive(false);
        tab[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(i > 0 && Input.GetKeyDown(keyCode_use))
        {
            use_potion();
            tab[i].SetActive(false); 
            i--;
            tab[i].SetActive(true);
        }
    }


    private void use_potion()
    {
        Gestion_Barre gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
        if (type_of_potion == 0)
            gestion_Barre.health_potion();

        else if (type_of_potion == 1)
            gestion_Barre.mana_potion();
    }


    public void one_kill_more()
    {
        nb_kill++;
        
        if(nb_kill > 10)
        {
            if (i < 5)
            {
                tab[i].SetActive(false);
                i++;
                tab[i].SetActive(true);
            }
            nb_kill = 0;
        }
    }
}
