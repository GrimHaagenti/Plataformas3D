using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newPlayerData", menuName ="Data/PlayerData/BaseData" )]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float crouchingVelocity = 1f;
    public float runningVelocity = 5f;
    public float maxSpeed;

    
    [Header("Jump State")]
    public float coyoteTime = 1f;
    public float gravity = 20f;
    public float max_fallSpeed = 10.0f;
    public bool alreadyJumped = false;

    [Header("Backflip Distance")]
    public float backflipDisplacementDistance = 20f;

    [Header("Jump Forces")]
    public float normalJumpForce = 0f;
     public float doubleJumpForce = 0f;
     public float tripleJumpForce = 0f;
     public float backflipJumpForce = 0f;
     public float longJumpForce =0f;

    [Header("Jump Times")]
    public float normalJumpTime = 0.5f;
    public float doubleJumpTime = 0.8f;
    public float tripleJumpTime = 1.3f;
    public float backflipJumpTime = 1.5f;
    public float longJumpTime = 1.5f;

    [Header("Jump distance")]
    public float normalJumpDistance = 20f;
    public float doubleJumpDistance = -1f;
    public float tripleJumpDistance = -1f;
    public float backflipJumpDistance = -1f;
    public float longJumpDistance = -1f;

    [Header("Jump Counter")]
    public int maxJumps = 3;
    public float jumpCounter = 0;

    public Vector3 finalVelocity = Vector3.zero;


 

}
