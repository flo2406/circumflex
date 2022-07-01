using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

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

    private Animator animator;
    private int IsThrowingHash;

    [SerializeField] private GameObject loot;
    private bool is_kill;

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
        rangeAttack = 15f;
        agent.speed = _speed;

        forceForward = 10000;
        time_between = 1.1f;
        last_attack = 0;

        animator = GetComponent<Animator>();
        IsThrowingHash = Animator.StringToHash("throw");
    }

    private void set_level()
    {
        Area_info info = GameObject.FindGameObjectWithTag("area_info").GetComponent<Area_info>();
        int val = info.get_area();

        Random r = new Random();

        if (val == 2)
        {
            _sante = r.Next(20, 30);
            _speed = r.Next(5,7);
            _dammages = r.Next(120, 150);
            _xp = r.Next(800, 1000);
        }

        else if (val == 5)
        {
            _sante = r.Next(150, 400);
            _speed = r.Next(10,15);
            _dammages = r.Next(400, 700);
            _xp = r.Next(1300, 1700);
        }

    }



    public void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, rangeFollow, playerMask);
        Collider[] players_near = Physics.OverlapSphere(transform.position, rangeAttack, playerMask);

        if (players_near.Length != 0)
        {
            animator.SetBool(IsThrowingHash, true);

            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(transform.position);

            if (Time.time > last_attack + time_between)
            {
                GameObject clone = Instantiate(attack, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);
                clone.GetComponent<Arrow_dammage>().set_dammages(_dammages);
                clone.transform.LookAt(player);
                clone.transform.rotation *= Quaternion.Euler(0, 90, 90);
                Vector3 val = transform.TransformDirection(Vector3.forward * forceForward);
                clone.GetComponent<Rigidbody>().AddForce(val);
                last_attack = Time.time;
            }
        }

        else if (players_collider.Length != 0)
        {
            animator.SetBool(IsThrowingHash, false);
            last_attack = Time.time - 0.1f;

            Transform player = players_collider[0].transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            agent.SetDestination(new Vector3(player.position.x, transform.position.y, player.position.z));
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

            GameObject loot_obj = Instantiate(loot);
            loot_obj.transform.position = gameObject.transform.position;
            Destroy(gameObject);

            Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
            spawn.decrease_monster_number();

            foreach (GameObject potion in GameObject.FindGameObjectsWithTag("potion"))
            {
                potion.GetComponent<Potion_advance>().one_kill_more();
            }
        }
    }

    

}
