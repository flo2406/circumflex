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
        speed = 5f;
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

        if ((targetPosition - transform.position).magnitude > 2)
        {
            targetPosition.y = transform.position.y;
            Vector3 relativePos = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 300 * Time.deltaTime);

            transform.position += (targetPosition - transform.position).normalized * speed * Time.deltaTime;
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    public Vector3 get_TargetPosition()
    {
        return targetPosition;
    }
}
