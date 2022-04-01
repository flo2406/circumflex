using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_attack : MonoBehaviour
{
    [SerializeField] GameObject attack;
    
    private float nextBomb;
    private float BombPoser;

    private float have_to_throw;

    private int forceForward;

    void Start()
    {
        nextBomb = 0f;
        BombPoser = 0.92f;
        have_to_throw = 0;

        forceForward = 10000;
    }


    void Update()
    {
        if (Time.time > have_to_throw && have_to_throw != 0)
        //if(Time.time > have_to_throw)
        {
            GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation);
            Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
            clone.GetComponent<Rigidbody>().AddForce(val);
            have_to_throw = 0;
            nextBomb = Time.time + BombPoser;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextBomb && have_to_throw == 0)
                have_to_throw = Time.time + 0.47f;
        }
    }
}
