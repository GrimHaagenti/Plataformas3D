using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    Player player;
    Animator animator;
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", player.GetCurrentVelocity());
        animator.SetFloat("X_Velocity", player.GetCurrentSpeedX());   
        animator.SetFloat("Z_Velocity", player.GetCurrentSpeedY());   
        //animator.SetBool("Crouching", player.isCrouching);   
        //animator.SetBool("Grounded", player.Grounded);   
        //animator.SetBool("Jumping", player.Jumping);   

    }
}
