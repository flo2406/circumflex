using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_UI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Player;
    private GameObject[] ennemies;

    void Start()
    {
        UI.SetActive(false);
        Player.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GameObject actual_description = UI.GetComponent<Description>().get_description();

            if (actual_description != null)
            {
                Destroy(actual_description);
                UI.GetComponent<Description>().set_description(null);
            }

            if (UI.activeSelf)
            {
                foreach (GameObject ennemy in ennemies)
                    ennemy.SetActive(true);

                UI.SetActive(false);
                Player.SetActive(true);
            }
            else
            {
                ennemies = GameObject.FindGameObjectsWithTag("ennemi");

                foreach (GameObject ennemy in ennemies)
                    ennemy.SetActive(false);

                UI.SetActive(true);
                Player.SetActive(false);
            }
        }
    }
}
