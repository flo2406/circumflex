using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_Inventary : MonoBehaviour
{
    public List<GameObject> inventary;
    void Awake()
    {
        inventary = new List<GameObject>();
    }
}
