using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private int IsWalkingHash;
    private int IsHittingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("walk");
        IsHittingHash = Animator.StringToHash("hit");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = gameObject.GetComponent<PlayerControl>().get_TargetPosition();

        bool isWalking = animator.GetBool(IsWalkingHash);
        bool isHitting = animator.GetBool(IsHittingHash);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool(IsHittingHash, true);
            animator.SetBool(IsWalkingHash, false);
        }
        else
        {
            animator.SetBool(IsHittingHash, false);
            if ((target_position - transform.position).magnitude > 2)
                animator.SetBool(IsWalkingHash, true);
            else
                animator.SetBool(IsWalkingHash, false);
        }
    }
}
