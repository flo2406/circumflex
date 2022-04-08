﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_attack : MonoBehaviour
{
    [SerializeField] GameObject attack;
    
    private float nextBomb;
    private float BombPoser;

    private float have_to_throw;

    private int forceForward;

    private KeyCode keyCode;

    void Start()
    {
        nextBomb = 0f;
        BombPoser = 0.92f;
        have_to_throw = 0;

        forceForward = 1000;

        keyCode = KeyCode.A;
    }


    void Update()
    {
        if (Time.time > have_to_throw && have_to_throw != 0)
        {
            GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation); 
            Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
            clone.GetComponent<Rigidbody>().AddForce(val);
            have_to_throw = 0;
            nextBomb = Time.time + BombPoser;
        }
        else
        {
            if (Input.GetKey(keyCode) && Time.time > nextBomb && have_to_throw == 0)
                have_to_throw = Time.time + 0.47f;
        }
    }
}
