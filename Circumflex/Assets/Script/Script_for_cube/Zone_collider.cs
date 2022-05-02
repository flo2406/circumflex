using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_collider : MonoBehaviour
{
    private int zone;
    void Start()
    {
        if(gameObject.name == "Plane")
        {
            zone = 1;
        }
        else if (gameObject.name == "Plane (1)")
        {
            zone = 2;
        }
        else if (gameObject.name == "Plane (2)")
        {
            zone = 3;
        }
        else 
        {
            zone = 4;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("new zone : " + zone);
            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.change_zone(zone);
        }
    }
}
