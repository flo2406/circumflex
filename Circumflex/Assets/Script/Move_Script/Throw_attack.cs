using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_attack : MonoBehaviour
{
    [SerializeField] GameObject attack;
    private float nextBomb;
    private float BombPoser;
    private int forceForward;

    void Start()
    {
        nextBomb = 0.5f;
        BombPoser = 0.5f;
        forceForward = 30000;
    }


    void Update()
    {
        float espace = Input.GetAxis("Jump");

        if (espace != 0 && Time.time > nextBomb)
        {
            nextBomb = Time.time + BombPoser;

            GameObject clone = Instantiate(attack, new Vector3 (transform.position.x,50,transform.position.z), transform.rotation);

            Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);

            clone.GetComponent<Rigidbody>().AddForce(val);
        }
    }
}
