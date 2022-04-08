using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    //private float speed;
    [SerializeField] private Camera cam;
    private Vector3 targetPosition;

    [SerializeField] private LayerMask ennemy_layer;
    private GameObject attack_ennemy;

    private GameObject see_ennemy;

    private NavMeshAgent agent;

    void Start()
    {
        //speed = 10f;
        targetPosition = transform.position;

        attack_ennemy = null;
        see_ennemy = null;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray see_ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit see_ennemy_hit;

        if (Physics.Raycast(cam.transform.position, see_ray.direction, out see_ennemy_hit, 1000, ennemy_layer))
        {
            if (see_ennemy != null && see_ennemy != see_ennemy_hit.transform.gameObject)
                see_ennemy.GetComponent<Outline>().enabled = false;

            see_ennemy = see_ennemy_hit.transform.gameObject;
            see_ennemy.GetComponent<Outline>().enabled = true;

        }
        else if (see_ennemy != null)
        {
            see_ennemy.GetComponent<Outline>().enabled = false;
            see_ennemy = null;
        }


        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit_ennemy;

            if (Physics.Raycast(cam.transform.position, ray.direction, out hit_ennemy, 1000, ennemy_layer))
            {
                if (Input.GetMouseButtonDown(0))
                    attack_ennemy = hit_ennemy.transform.gameObject;
                else
                    targetPosition = hit_ennemy.point;
            }

            else
            {
                attack_ennemy = null;

                RaycastHit hit;
                Physics.Raycast(cam.transform.position, ray.direction, out hit, 1000);
                targetPosition = hit.point;
            }
        }

        if (attack_ennemy != null)
        {  
            targetPosition = attack_ennemy.transform.position;
            targetPosition.y = transform.position.y;

            if ((targetPosition - transform.position).magnitude < 3f)
            {
                Debug.Log("Anim");
                gameObject.GetComponent<Animations>().set_slash_anim(attack_ennemy);
                attack_ennemy = null;
            }
        }

        if ((targetPosition - transform.position).magnitude > 0.1f)
        {
            /*targetPosition.y = transform.position.y;
            Vector3 relativePos = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 500 * Time.deltaTime);

            transform.position += (targetPosition - transform.position).normalized * speed * Time.deltaTime;*/

            targetPosition.y = transform.position.y;
            agent.SetDestination(targetPosition);
        }


    }

    public Vector3 get_TargetPosition()
    {
        return targetPosition;
    }
}
