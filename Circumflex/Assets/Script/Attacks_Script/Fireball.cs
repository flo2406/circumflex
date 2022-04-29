using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject attack;
    private int forceForward;
    private KeyCode keyCode;

    void Start()
    {
        forceForward = 1000;
        keyCode = KeyCode.A;
    }

    void Update()
    {
        if(Input.GetKey(keyCode))
        {
            gameObject.GetComponentInParent<Animations>().set_throw_anim("fireball");
        }
    }

    public void send_attack()
    {
        GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
        clone.GetComponent<Dammages>().set_type_of_attack("fireball");
        Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
        clone.GetComponent<Rigidbody>().AddForce(val);
    }

}
