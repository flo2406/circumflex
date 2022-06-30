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
    private GameObject clone_anim;

    private int reset_anim;
    private int reset_invoc;

    private Animator animator;
    private int IsInvocationHash;
    private int IsAnimationHash;

    [SerializeField] private LayerMask playerMask;

    private bool is_kill;

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
        clone_anim = null;

        is_kill = false;

        set_level();    
        
        animator = GetComponent<Animator>();
        IsInvocationHash = Animator.StringToHash("invoc");
        IsAnimationHash = Animator.StringToHash("attack");
    }

    private void set_level()
    {
        _sante = 5000;
        _dammages = 200;
        _xp = 4000;
    }

    void Update()
    {
        Collider[] players_collider = Physics.OverlapSphere(transform.position, 100, playerMask);
       
        if(players_collider.Length > 0)
        {
            Transform player = players_collider[0].gameObject.transform;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

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
            clone_anim = clone;
            Destroy(clone, 2f);
            timer_anim = 0;
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
        Instantiate(invoc, new Vector3(5, 0, 0), Quaternion.identity, gameObject.transform);
        Instantiate(invoc, new Vector3(-5, 0, 0), Quaternion.identity, gameObject.transform);
        Instantiate(invoc, new Vector3(0, 0, 5), Quaternion.identity, gameObject.transform);
        Instantiate(invoc, new Vector3(0, 0, -5), Quaternion.identity, gameObject.transform);
    }

    public void take_dammages(float dammages)
    {
        _sante -= dammages;
        if (_sante <= 0 && !is_kill)
        {
            is_kill = true;

            Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
            stat.gain_experience(stat.get_wisdom() / 20 * _xp);

            Destroy(gameObject);

            foreach (GameObject potion in GameObject.FindGameObjectsWithTag("potion"))
            {
                potion.GetComponent<Potion_advance>().one_kill_more();
            }
        }
    }



}
