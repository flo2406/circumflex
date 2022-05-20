using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Randoms = System.Random;
using Random = UnityEngine.Random;

public class Archerie_AI : MonoBehaviour
{
    [SerializeField] private GameObject attack;
    private float forceForward;
    private float time_between;
    private float last_attack;

    private NavMeshAgent agent;
    private int rangeFollow;
    private float rangeAttack;

    [SerializeField] private LayerMask playerMask;

    /*private Animator animator;
    private int IsWalkingHash;
    private int IsPunchingHash;
    private float start_punch_anim;
    private float end_punch_anim;*/

    private float sante;
    [SerializeField] private GameObject loot;
    private bool is_kill;

    private Gestion_Barre gestion_Barre;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sante = 100;
        is_kill = false;

        rangeFollow = 50;
        rangeAttack = 15f;

        forceForward = 10000;
        time_between = 1f;
        last_attack = 0;

        /*animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("walk");
        IsPunchingHash = Animator.StringToHash("punch");
        start_punch_anim = -1;
        end_punch_anim = -1;*/

        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
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

            if (Time.time > last_attack + time_between)
            {
                GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
                Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
                clone.GetComponent<Rigidbody>().AddForce(val);
                last_attack = Time.time;
            }
        }

        else if (players_collider.Length != 0)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
    }


    public void take_dammages(float dammages)
    {
        sante -= dammages;
        if (sante <= 0 && !is_kill)
        {
            is_kill = true;

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * 600);

            GameObject loot_obj = Instantiate(loot);
            loot_obj.transform.position = gameObject.transform.position;
            Destroy(gameObject);

            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.decrease_monster_number();
        }
    }

    

}
