using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Tornado : MonoBehaviour
{
    [SerializeField] private GameObject tornado;
    private KeyCode keyCode;
    void Start()
    {
        tornado.SetActive(false);
        keyCode = KeyCode.E;
    }

    void Update()
    {
        if (Input.GetKey(keyCode))
            tornado.SetActive(true);
        else
            tornado.SetActive(false);
    }
}