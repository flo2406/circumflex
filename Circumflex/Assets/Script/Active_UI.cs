using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_UI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Player;

    void Start()
    {
        UI.active = false;
        Player.active = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(UI.active)
            {
                UI.active = false;
                Player.active = true;
            }
            else
            {
                UI.active = true;
                Player.active = false;
            }
        }
    }
}
