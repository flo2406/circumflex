using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_direction : MonoBehaviour
{
    [SerializeField] private GameObject boss1;
    [SerializeField] private GameObject boss2;
    void Update()
    {
        if(boss1 != null)
            transform.LookAt(new Vector3(boss1.transform.position.x, transform.position.y, boss1.transform.position.z));
        else if (boss2 != null)
            transform.LookAt(new Vector3(boss2.transform.position.x, transform.position.y, boss2.transform.position.z));
    }
}
