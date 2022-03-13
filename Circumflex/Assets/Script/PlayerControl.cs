using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    private Rigidbody playerRigid;
    [SerializeField] private Camera cam;
    private Vector3 targetPosition;
    private bool release;

    void Start()
    {
        speed = 100f;
        playerRigid = GetComponent<Rigidbody>();
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
            transform.position += (targetPosition - transform.position).normalized * speed * Time.deltaTime;
        }
    }



    void RotateTo(Vector3 vec, float sensi)
    {
        transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
    }

}
