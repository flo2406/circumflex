using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControl control;
    private int IsWalkingHash;
    private int IsThrowingHash;
    private int IsSlashingHash;
    private int IsHittingHash;
    private int IsLaserHash;
    private int IsSpinningHash;

    private bool is_slash;
    private float slash_time;

    private GameObject ennemy;

    private bool is_throw;
    private float throw_time;
    private bool is_sent;
    [SerializeField] private GameObject mechanics;

    void Start()
    {
        IsWalkingHash = Animator.StringToHash("walk");
        IsThrowingHash = Animator.StringToHash("throw");
        IsSlashingHash = Animator.StringToHash("slash");
        IsHittingHash = Animator.StringToHash("hit");
        IsSpinningHash = Animator.StringToHash("spin");

        is_throw = false;
        throw_time = 0;

        is_slash = false;
        slash_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = control.get_TargetPosition();

        bool isWalking = animator.GetBool(IsWalkingHash);
        bool isThrowing = animator.GetBool(IsThrowingHash);
        bool isSlashing = animator.GetBool(IsSlashingHash);

        if (is_slash)
        {
            if (slash_time == 0)
                slash_time = Time.time;
            else if (Time.time > slash_time + 1)
            {
                Stats stat = GameObject.FindWithTag("stat").GetComponent<Stats>();
                float dammage = stat.get_strength() * 20;

                ennemy.GetComponent<AI>().take_dammages(dammage);
                slash_time = 0;
                is_slash = false;
                clear_slash_anim();
            }
        }


        else if (is_throw)
        {
            if (throw_time == 0)
            {
                is_sent = false;
                throw_time = Time.time;
            }
            else if (Time.time > throw_time + 0.5f && !is_sent)
            {
                is_sent = true;

                mechanics.GetComponent<Fireball>().send_attack();
            }

            else if (Time.time > throw_time + 1.4f)
            {
                throw_time = 0;
                is_throw = false;
                clear_throw_anim();
            }
        }

        else
        {
            if ((target_position - control.gameObject.transform.position).magnitude > 0.5f)
                animator.SetBool(IsWalkingHash, true);
            else
                animator.SetBool(IsWalkingHash, false);
        }
    }

    public void set_hit_anim()
    {
        animator.SetBool(IsHittingHash, true);
    }
    public void clear_hit_anim()
    {
        animator.SetBool(IsHittingHash, false);
    }


    public void set_slash_anim(GameObject ennemy)
    {
        this.ennemy = ennemy;
        animator.SetBool(IsSlashingHash, true);
        is_slash = true;
    }

    public void clear_slash_anim()
    {
        animator.SetBool(IsWalkingHash, true);
        animator.SetBool(IsSlashingHash, false);
    }

    public void set_throw_anim(string ele)
    {
        animator.SetBool(IsThrowingHash, true);
        is_throw = true;
    }

    public void clear_throw_anim()
    {
        animator.SetBool(IsWalkingHash, true);
        animator.SetBool(IsThrowingHash, false);
    }

    public void set_tornado_anim()
    {
        animator.SetBool(IsSpinningHash, true);
    }

    public void clear_tornado_anim()
    {
        animator.SetBool(IsSpinningHash, false);
    }

}
