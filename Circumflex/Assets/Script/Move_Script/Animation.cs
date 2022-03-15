using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private int IsWalkingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("walk");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = gameObject.GetComponent<PlayerControl>().get_TargetPosition();

        bool isWalking = animator.GetBool(IsWalkingHash);

        if ((target_position - transform.position).magnitude > 2)
            animator.SetBool(IsWalkingHash, true);
        else
            animator.SetBool(IsWalkingHash, false);
    }
}
