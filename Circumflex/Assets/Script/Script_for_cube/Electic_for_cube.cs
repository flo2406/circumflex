using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electic_for_cube : MonoBehaviour
{
    [SerializeField] GameObject attack;
    private int forceForward;
    private KeyCode keyCode;

    private bool have_to_send;

    void Start()
    {
        forceForward = 1000;
        keyCode = KeyCode.R;

        have_to_send = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            have_to_send = true;

        if (Input.GetKeyUp(keyCode))
            have_to_send = false;

        if (have_to_send)
        {
            GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
            clone.GetComponent<Dammages_for_cube>().set_type_of_attack("electrical");
            Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
            clone.GetComponent<Rigidbody>().AddForce(val);
        }


    }
}
