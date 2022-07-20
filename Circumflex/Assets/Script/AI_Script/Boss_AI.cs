using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_AI : MonoBehaviour
{
    [SerializeField] private GameObject anim;
    [SerializeField] private GameObject invoc;

    private float time_anim;
    private float time_invoc;
    private float time_between;
    private float time_before_anim;
    private float timer_anim;

    private int reset_anim;
    private int reset_invoc;

    private bool reset_anim_hit;

    private Animator animator;
    private int IsInvocationHash;
    private int IsAnimationHash;

    [SerializeField] private LayerMask playerMask;

    private bool is_kill;
    [SerializeField] private GameObject to_open;

    // Stat
    private float _sante;
    private int _dammages;
    private int _xp;


    void Start()
    {
        time_anim = 0;
        time_invoc = 7.5f;
        time_between = 15;
        time_before_anim = 1.5f;
        timer_anim = 0;
        reset_anim_hit = false;

        is_kill = false;

        set_level();    
        
        animator = GetComponent<Animator>();
        IsInvocationHash = Animator.StringToHash("invoc");
        IsAnimationHash = Animator.StringToHash("attack");
    }

    private void set_level()
    {
        Area_info info = GameObject.FindGameObjectWithTag("area_info").GetComponent<Area_info>();
        int val = info.get_area();

        if (val == 3)
        {
            _sante = 2000;
            _dammages = 400;
            _xp = 4000;
        }
        else
        {
            _sante = 15000;
            _dammages = 1200;
            _xp = 15000;
        }

    }

    void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, 100, playerMask);
       
        if(players_collider.Length > 0)
        {
            Transform player = players_collider[0].gameObject.transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

        if (reset_anim_hit)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animations>().clear_hit_anim();

        if (reset_anim == 1)
            reset_anim++;

        if (reset_invoc == 1)
            reset_invoc++;

        if (reset_anim == 2)
            animator.SetBool(IsAnimationHash, false);

        if (reset_invoc == 2)
            animator.SetBool(IsInvocationHash, false);

        if(timer_anim != 0 && timer_anim + time_before_anim < Time.time)
        {
            GameObject clone = Instantiate(anim, transform);
            Destroy(clone, 2f);
            timer_anim = 0;

            Collider[] dammage_collider = Physics.OverlapSphere(transform.position, 15, playerMask);
            if(dammage_collider.Length > 0)
            {
                dammage_collider[0].gameObject.GetComponent<Animations>().set_hit_anim();
                GameObject stat = GameObject.FindWithTag("stat");
                float damage = _dammages / 20;
                Gestion_Barre gestion_Barre = GameObject.FindGameObjectWithTag("barre").GetComponent<Gestion_Barre>();
                gestion_Barre.make_damages(damage);
                reset_anim_hit = true;
            }

        }

        if (time_anim < Time.time)
            attack_anim();

        if (time_invoc < Time.time)
            instanciate_attack();

    }


    public void attack_anim()
    {
        animator.SetBool(IsAnimationHash, true);
        reset_anim = 1;
        time_anim += time_between;
        timer_anim = Time.time;
    }

    public void instanciate_attack()
    {
        animator.SetBool(IsInvocationHash, true);
        reset_invoc = 1;
        time_invoc += time_between;

        Area_info info = GameObject.FindGameObjectWithTag("area_info").GetComponent<Area_info>();
        int zone = info.get_area();

        if(gameObject.name == "Boss1")
        {
            Instantiate(invoc, new Vector3(24.4f, 1.3f, 388.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(4.4f, 1.3f, 388.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(14.4f, 1.3f, 398.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(14.4f, 1.3f, 378.7f), Quaternion.identity);
        }
        else
        {
            Instantiate(invoc, new Vector3(24.4f, 1.3f, 998.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(4.4f, 1.3f, 998.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(14.4f, 1.3f, 1008.7f), Quaternion.identity);
            Instantiate(invoc, new Vector3(14.4f, 1.3f, 988.7f), Quaternion.identity);
        }


        Spawn spawn = GameObject.FindGameObjectWithTag("spawn").GetComponent<Spawn>();
        spawn.increase_monster_number();
        spawn.increase_monster_number();
        spawn.increase_monster_number();
        spawn.increase_monster_number();
    }

    public void take_dammages(float dammages)
    {
        _sante -= dammages;
        if (_sante <= 0 && !is_kill)
        {
            is_kill = true;

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * _xp);

            to_open.SetActive(false);
            Destroy(gameObject);

            foreach (GameObject potion in GameObject.FindGameObjectsWithTag("potion"))
            {
                potion.GetComponent<Potion_advance>().one_kill_more();
            }
        }
    }

}
