using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Randoms = System.Random;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    //private float sante;
    private int range;

    [SerializeField] private LayerMask playerMask;


    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //sante = 100;
        range = 120;
    }

    public void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, range, playerMask);

        if (players_collider.Length != 0)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

}
