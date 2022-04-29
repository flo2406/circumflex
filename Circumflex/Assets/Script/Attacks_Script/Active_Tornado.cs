using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Tornado : MonoBehaviour
{
    [SerializeField] private GameObject tornado;
    private KeyCode keyCode;
    private bool active;
    void Start()
    {
        active = false;
        tornado.SetActive(false);
        keyCode = KeyCode.E;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (!active)
            {
                gameObject.GetComponentInParent<Animations>().set_tornado_anim();
                tornado.SetActive(true);
                active = true;
            }
            else
            {
                gameObject.GetComponentInParent<Animations>().clear_tornado_anim();
                tornado.SetActive(false);
                active = false;
            }
        }
    }
}