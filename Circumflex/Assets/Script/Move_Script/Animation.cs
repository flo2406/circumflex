using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControl control;
    private int IsWalkingHash;
    private int IsThrowingHash;
    private int IsSlashingHash;

    private bool is_throw;
    private float throw_time; 

    void Start()
    {
        IsWalkingHash = Animator.StringToHash("walk");
        IsThrowingHash = Animator.StringToHash("throw");
        IsSlashingHash = Animator.StringToHash("slash");

        is_throw = false;
        throw_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = control.get_TargetPosition();

        bool isWalking = animator.GetBool(IsWalkingHash);
        bool isThrowing = animator.GetBool(IsThrowingHash);
        bool isSlashing = animator.GetBool(IsSlashingHash);


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
            if ((target_position - control.gameObject.transform.position).magnitude > 2)
                animator.SetBool(IsWalkingHash, true);
            else
                animator.SetBool(IsWalkingHash, false);
        }
    }
}
