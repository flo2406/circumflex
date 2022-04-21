using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    [SerializeField] private Transform perso;
    private float difX;
    private float difY;
    private float difZ;

    void Start()
    {
        difX = -12.2f;
        difY = 10.42f;
        difZ = -0.2f;
    }

    void Update()
    {
        transform.position = new Vector3(perso.position.x + difX, perso.position.y + difY, perso.position.z + difZ);
    }
}