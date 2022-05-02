using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Collider : MonoBehaviour
{
    private int zone;
    void Start()
    {
        if (gameObject.name == "Terrain1")
        {
            zone = 1;
        }
        else if (gameObject.name == "Terrain2")
        {
            zone = 2;
        }
        else if (gameObject.name == "Terrain3")
        {
            zone = 3;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("new zone : " + zone);
            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.change_zone(zone);
        }
    }
}
