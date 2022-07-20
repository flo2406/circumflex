using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

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

    [SerializeField] private float sante;
    [SerializeField] private GameObject loot;
    private bool is_kill;

    private Gestion_Barre gestion_Barre;

    // Stat
    private float _sante;
    private float _speed;
    private int _dammages;
    private int _xp;

    public void Awake()
    {
        set_level();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = _speed;

        is_kill = false;

        rangeFollow = 50;
        rangeAttack = 7f;


        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("walk");
        IsPunchingHash = Animator.StringToHash("punch");
        start_punch_anim = -1;
        end_punch_anim = -1;
        
        gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
    }


    private void set_level()
    {
        Area_info info = GameObject.FindGameObjectWithTag("area_info").GetComponent<Area_info>();
        int val = info.get_area();

        Random r = new Random();

        if (val == 4)
        {
            _sante = r.Next(200, 300);
            _speed = (float)r.NextDouble();
            _dammages = r.Next(400, 700);
            _xp = r.Next(2000, 2500);
        }


        else if (val == 5)
        {
            _sante = r.Next(250, 400);
            _speed = (float)r.NextDouble() * 2;
            _dammages = r.Next(600, 900);
            _xp = r.Next(2500, 3500);
        }

        else if (val == 6)
        {
            _sante = r.Next(1000, 1500);
            _speed = (float)r.NextDouble() * 3;
            _dammages = r.Next(1000, 1500);
            _xp = r.Next(4000, 5000);
        }

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

            bool shield = player.GetComponentInChildren<Active_Shield>().have_shield();

            if(!shield)
                throw_anim(player, true);
        }

        else if (players_collider.Length != 0)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));

            animator.SetBool(IsWalkingHash, true);
            animator.SetBool(IsPunchingHash, false);

            bool shield = player.GetComponentInChildren<Active_Shield>().have_shield();

            if (!shield)
                throw_anim(player, false);
        }
        else
        {
            Destroy(gameObject);

            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.decrease_monster_number(false);

            /*foreach (GameObject potion in GameObject.FindGameObjectsWithTag("potion"))
            {
                potion.GetComponent<Potion_advance>().one_kill_more();
            }*/
        }
    }

    
    public void take_dammages(float dammages)
    {
        _sante -= dammages;
        if(_sante <= 0 && !is_kill)
        {
            is_kill = true;

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * _xp);


            Random r = new Random();
            if(r.Next(0,100) > 60)
            {
                GameObject loot_obj = Instantiate(loot);
                loot_obj.transform.position = gameObject.transform.position;
            }

            Destroy(gameObject);

            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.decrease_monster_number(true);

            foreach (GameObject potion in GameObject.FindGameObjectsWithTag("potion"))
            {
                potion.GetComponent<Potion_advance>().one_kill_more();
            }

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

                GameObject stat = GameObject.FindWithTag("stat");
                float damage = _dammages / stat.GetComponent<Stats>().get_defense();
                gestion_Barre.make_damages(damage);
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
