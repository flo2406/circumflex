using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    [SerializeField] private Camera cam;
    private Vector3 targetPosition;
    private bool release;

    void Start()
    {
        speed = 10f;
        targetPosition = transform.position;
        release = true;
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && release)
        {   
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(cam.transform.position,ray.direction,out hit, 1000);
            targetPosition = hit.point;
            release = false;
        }
        if(!Input.GetMouseButton(0))
            release = true;

        if ((targetPosition - transform.position).magnitude > 0.1f)
        {
            targetPosition.y = transform.position.y;
            Vector3 relativePos = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 500 * Time.deltaTime);

            transform.position += (targetPosition - transform.position).normalized * speed * Time.deltaTime;
        }
    }

    public Vector3 get_TargetPosition()
    {
        return targetPosition;
    }
}
