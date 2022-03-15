using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    [SerializeField] private Transform perso;
    private float difX;
    private float difZ;

    void Start()
    {
        difX = transform.position.x - perso.position.x;
        difZ = transform.position.z - perso.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(perso.position.x + difX, transform.position.y, perso.position.z + difZ);
    }
}