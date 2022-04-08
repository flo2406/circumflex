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

    private bool is_throw;
    private float throw_time;

    private bool is_slash;
    private float slash_time;

    private GameObject ennemy;

    void Start()
    {
        IsWalkingHash = Animator.StringToHash("walk");
        IsThrowingHash = Animator.StringToHash("throw");
        IsSlashingHash = Animator.StringToHash("slash");
        IsHittingHash = Animator.StringToHash("hit");

        is_throw = false;
        throw_time = Time.time;

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

        if(is_slash)
        {
            if (slash_time == 0)
                slash_time = Time.time;
            else if (Time.time > slash_time + 1)
            {
                ennemy.GetComponent<AI>().make_dammages(50);
                slash_time = 0;
                is_slash = false;
                clear_slash_anim();
            }
        }


        if(is_throw)
        {
            if(Time.time > throw_time + 1)
                is_throw = false;
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool(IsThrowingHash, true);
            animator.SetBool(IsWalkingHash, false);
            is_throw = true;
            throw_time = Time.time;
        }
        else
        {
            animator.SetBool(IsThrowingHash, false);
            if ((target_position - control.gameObject.transform.position).magnitude > 0.1f)
                animator.SetBool(IsWalkingHash, true);
            else
                animator.SetBool(IsWalkingHash, false);
        }
    }

    public void throw_hit_anim()
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
}
