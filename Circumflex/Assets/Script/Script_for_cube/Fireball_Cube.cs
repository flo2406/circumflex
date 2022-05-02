using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Cube : MonoBehaviour
{

    [SerializeField] GameObject attack;
    private int forceForward;
    private KeyCode keyCode;
    private float last_throw;

    void Start()
    {
        forceForward = 1000;
        keyCode = KeyCode.A;
        last_throw = 0;
    }

    void Update()
    {
        if (Input.GetKey(keyCode) && last_throw + 1f < Time.time)
        {
            send_attack();
            last_throw = Time.time;
        }
    }
    public void send_attack()
    {
        GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
        clone.GetComponent<Dammages_for_cube>().set_type_of_attack("fireball");
        Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
        clone.GetComponent<Rigidbody>().AddForce(val);
    }
}
