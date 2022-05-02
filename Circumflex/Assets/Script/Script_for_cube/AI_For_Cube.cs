using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Randoms = System.Random;
using Random = UnityEngine.Random;

public class AI_For_Cube : MonoBehaviour
{
    private NavMeshAgent agent;
    private int rangeFollow;
    private float rangeAttack;

    [SerializeField] private LayerMask playerMask;

    private float sante;
    [SerializeField] private GameObject loot;

    private Gestion_Barre gestion_Barre;

    private float attack_time;

    private bool is_kill;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sante = 100;
        rangeFollow = 50;
        rangeAttack = 4f;

        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();

        attack_time = 0f;

        is_kill = false;
    }

    public void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, rangeFollow, playerMask);
        Collider[] players_near = Physics.OverlapSphere(transform.position, rangeAttack, playerMask);

        if (players_near.Length != 0)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(transform.position);

            attack();
        }

        else if (players_collider.Length != 0)
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


    public void take_dammages(float dammages)
    {
        sante -= dammages;
        if (sante <= 0 && !is_kill)
        {
            is_kill = true;

            GameObject loot_obj = Instantiate(loot);
            loot_obj.transform.position = gameObject.transform.position;
            Destroy(gameObject);

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * 600);

            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.decrease_monster_number();
        }
    }

    void attack()
    {
        if(Time.time > attack_time + 2f)
        {
            attack_time = Time.time;
            gestion_Barre.make_damages(10f);
        }
    }
}
