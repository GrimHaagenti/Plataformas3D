using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newPlayerData", menuName ="Data/PlayerData/BaseData" )]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float velocityXZ = 5f;
    
    [Header("Jump State")]
    public float coyoteTime = 1f;
    public float gravity = 20f;
    public float jumpForce = 10f;
    public float max_fallSpeed = 10.0f;


   public Vector3 finalVelocity = Vector3.zero;

}
