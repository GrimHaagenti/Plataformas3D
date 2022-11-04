using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newPlayerData", menuName ="Data/PlayerData/BaseData" )]
public class PlayerData : ScriptableObject
{
    public enum JumpsEnum { NORMALJUMP, DOUBLEJUMP, TRIPLEJUMP, _NO_JUMP};

    [Header("Move State")]
    public float crouchingVelocity = 1f;
    public float runningVelocity = 5f;
    public float accel = 0.5f;
    public float deaccel = 0.8f;
    public float maxSpeed = 5f;
    public float currentAccel = 0f;
    [Header("Camera Rotation")]
    public float turnSmoothSpeed = 3f;
    public float turnSmoothTime = 0.1f;


    public float lastXInput = 0;
    public float lastYInput = 0;
    [Header("Jump State")]
    public float coyoteTime = 1f;
    public float gravity = 20f;
    public float wallSlideGravity = 5f;
    public float max_fallSpeed = 10.0f;
    public float maxTimeToAdvanceJump = 1f;
    public float gravitySmoothingHeadstart = 0.3f;
    public bool alreadyJumped = false;
    public JumpsEnum currentJump = JumpsEnum._NO_JUMP;

    [Header("Backflip Distance")]
    public float backflipDisplacementDistance = 20f;

    [Header("Jump Forces")]
    public float normalJumpForce = 0f;
     public float doubleJumpForce = 0f;
     public float tripleJumpForce = 0f;
     public float backflipJumpForce = 0f;
     public float longJumpForce =0f;
    public float wallJumpForce = 0f;

    [Header("Jump Times")]
    public float normalJumpTime = 0.5f;
    public float doubleJumpTime = 0.8f;
    public float tripleJumpTime = 1.3f;
    public float backflipJumpTime = 1.5f;
    public float longJumpTime = 1.5f;
    public float wallJumpTime = 0.8f;

    [Header("Jump distance")]
    public float normalJumpDistance = 20f;
    public float doubleJumpDistance = -1f;
    public float tripleJumpDistance = -1f;
    public float backflipJumpDistance = -1f;
    public float longJumpDistance = -1f;
    public float wallJumpDistance = 20f;

    [Header("Jump Counter")]
    public int maxJumps = 3;
    public float jumpCounter = 0;

    [Header("Wall State")]
    public bool wallLand = false;
    public bool wallStay = false;
    public bool wallExit = false;
    public float wallJumpDisplacement = 200f;


    public Vector3 finalVelocity = Vector3.zero;


 

}
