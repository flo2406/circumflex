using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    private GameObject actual_description;

    void Start()
    {
        actual_description = null;
    }

    public GameObject get_description()
    {
        return actual_description;
    }

    public void set_description(GameObject new_description)
    {
        actual_description = new_description;
    }
}
