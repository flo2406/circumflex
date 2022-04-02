using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_UI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Player;

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
                UI.SetActive(false);
                Player.SetActive(true);
            }
            else
            {
                UI.SetActive(true);
                Player.SetActive(false);
            }
        }
    }
}
