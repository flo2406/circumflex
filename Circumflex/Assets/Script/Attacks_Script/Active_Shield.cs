using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private GameObject gameObject_shield;
    void Start()
    {
        gameObject_shield = Instantiate(shield, transform.position, Quaternion.identity);
    }

    void Update()
    {
        gameObject_shield.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }
}
