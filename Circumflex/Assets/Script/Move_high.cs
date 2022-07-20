using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_high : MonoBehaviour
{
    private float y;
    private bool activated;

    private float time_between_act;
    private float last_act;

    void Start()
    {
        y = 68;
        set_y();
        activate();
        time_between_act = 30;
    }

    void Update()
    {
        Debug.Log(y);
        set_y();
        if (activated && y < 72)
            y += 0.003f;

        else if (activated)
            activated = false;

        else if (y > 68)
            y-= 0.003f;

        //if (last_act + time_between_act < Time.time)
            //activate();

    }

    private void activate()
    {
        activated = true;
        y += 0.01f;
        last_act = Time.time;
    }

    private void set_y()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, y, gameObject.transform.localPosition.z);
    }
}
