using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private KeyCode keyCode;
    void Start()
    {
        shield.SetActive(false);
        //keyCode = KeyCode.Z;
        keyCode = KeyCode.W;
    }

    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            shield.SetActive(!shield.activeSelf);
        }
    }
}
