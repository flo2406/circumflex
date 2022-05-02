using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_rotation : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    
    void Update()
    {
        transform.eulerAngles = parent.transform.eulerAngles;
    }
}
