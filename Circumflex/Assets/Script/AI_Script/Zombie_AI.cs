using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Zombie_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    private int rangeFollow;
    private float rangeAttack;
    private float rangeCheck;

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask ennemyMask;

    private Animator animator;
    private int IsPunchingHash;
    private float start_punch_anim;
    private float end_punch_anim;

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

        is_kill = false;

        rangeFollow = 50;
        rangeAttack = 2f;
        rangeCheck = 5f;
        agent.speed = _speed;


        animator = GetComponent<Animator>();
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

        if(val == 1)
        {
            _sante = r.Next(20, 30);
            _speed = (float)r.NextDouble();
            _dammages = r.Next(150, 200);
            _xp = r.Next(300, 500);
        }


        else if(val == 2)
        {
            _sante = r.Next(50, 70);
            _speed = (float) r.NextDouble() * 2;
            _dammages = r.Next(300, 500);
            _xp = r.Next(500, 700);
        }

        else if (val == 3)
        {
            _sante = r.Next(100, 150);
            _speed = (float)r.NextDouble() * 3;
            _dammages = r.Next(400, 700);
            _xp = r.Next(900, 1300);
        }

    }

    public void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, rangeFollow, playerMask);
        Collider[] players_near = Physics.OverlapSphere(transform.position, rangeAttack, playerMask);

        Collider[] ennemies_near = Physics.OverlapSphere(transform.position, rangeCheck, ennemyMask);

        if (players_near.Length != 0 && ennemies_near.Length <= 7)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(transform.position);

            animator.SetBool(IsPunchingHash, true);

            bool shield = player.GetComponentInChildren<Active_Shield>().have_shield();

            if (!shield)
                throw_anim(player, true);
        }

        else if (players_collider.Length != 0 && ennemies_near.Length <= 7)
        {
            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));

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
        }
    }


    public void take_dammages(float dammages)
    {
        _sante -= dammages;
        if (_sante <= 0 && !is_kill)
        {
            is_kill = true;

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * _xp);

            Random r = new Random();
            if (r.Next(0, 100) > 60)
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
            if (Time.time > end_punch_anim + 1.7f)
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
                float damage = _dammages / 20;
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
