using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{

    [SerializeField] private Camera cam;

    // Update is called once per frame
    /*void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(cam.transform.position, ray.direction, out hit, 1000);

        transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
    }*/
}
