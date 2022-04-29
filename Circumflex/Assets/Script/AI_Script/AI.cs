using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Randoms = System.Random;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    private int rangeFollow;
    private float rangeAttack;

    [SerializeField] private LayerMask playerMask;


    private Animator animator;
    private int IsWalkingHash;
    private int IsPunchingHash;
    private float start_punch_anim;
    private float end_punch_anim;

    private float sante;
    [SerializeField] private GameObject loot;

    private Gestion_Barre gestion_Barre;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sante = 100;
        rangeFollow = 120;
        rangeAttack = 2f;


        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("walk");
        IsPunchingHash = Animator.StringToHash("punch");
        start_punch_anim = -1;
        end_punch_anim = -1;

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

            animator.SetBool(IsWalkingHash, false);
            animator.SetBool(IsPunchingHash, true);

            throw_anim(player, true);
        }

        else if (players_collider.Length != 0)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));

            animator.SetBool(IsWalkingHash, true);
            animator.SetBool(IsPunchingHash, false);

            throw_anim(player, false);
        }
        else
        {
            agent.SetDestination(transform.position);

            animator.SetBool(IsWalkingHash, false);
            animator.SetBool(IsPunchingHash, false);
        }
    }

    
    public void take_dammages(float dammages)
    {
        sante -= dammages;
        if(sante <= 0)
        {
            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(600);

            GameObject loot_obj = Instantiate(loot);
            loot_obj.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }

    void throw_anim(Transform player, bool in_attack_range)
    {
        if (end_punch_anim != -1)
        {
            player.gameObject.GetComponent<Animations>().clear_hit_anim();
            if (Time.time > end_punch_anim + 1f)
                end_punch_anim = -1;
        }

        else if (start_punch_anim != -1 && Time.time > start_punch_anim + 1f)
        {
            if (Physics.OverlapSphere(transform.position, 7f, playerMask).Length > 0)
            {
                start_punch_anim = -1;
                end_punch_anim = Time.time;
                player.gameObject.GetComponent<Animations>().set_hit_anim();
                gestion_Barre.make_damages(50f);
            }
            else
            {
                start_punch_anim = -1;
                end_punch_anim = -1;
            }
        }
        else if (start_punch_anim == -1 && in_attack_range)
            start_punch_anim = Time.time;
    }

}
