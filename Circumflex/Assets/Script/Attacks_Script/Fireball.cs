using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject attack;
    private int forceForward;
    private KeyCode keyCode;
    private Gestion_Barre gestion_Barre;
    private bool throwed;

    void Start()
    {
        throwed = false;
        forceForward = 1000;
        //keyCode = KeyCode.A;
        keyCode = KeyCode.Q;
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }

    void Update()
    {
        bool shield = GetComponent<Active_Shield>().have_shield();
        if (shield)
            return;

        if (Input.GetKey(keyCode) && (throwed || gestion_Barre.use_mana(20f)))
        {
            throwed = true;
            gameObject.GetComponentInParent<Animations>().set_throw_anim("fireball");
        }
    }

    public void send_ball()
    {
        GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
        clone.GetComponent<Dammages>().set_type_of_attack("fireball");
        Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
        clone.GetComponent<Rigidbody>().AddForce(val);
    }


    public void send_attack()
    {
        send_ball();
        gameObject.transform.Rotate(Vector3.up, 10f);
        send_ball();
        gameObject.transform.Rotate(Vector3.up, -20f);
        send_ball();
        gameObject.transform.Rotate(Vector3.up, 10f);
        throwed = false;
    }

}
