using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLongJumpState : PlayerJumpingState
{
    float timer = 0;
    float maxTime = 1f;
    public PlayerLongJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.finalVelocity = (player.transform.forward * playerData.longJumpDisplacement* playerData.backflipJumpForce) * Time.deltaTime; 
    
        yVelocity =playerData.longJumpForce;
        Debug.Log("Impulse:   " + playerData.finalVelocity);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;
        //Debug.Log("Should Applied Impulse:   " + playerData.finalVelocity);

        base.LogicUpdate();
        //if (timer > maxTime)
        //{
        //    if (player.Controller.isGrounded)
        //    {
        //        stateMachine.ChangeState(player.LandState);
        //    }
        //}
        //timer += Time.deltaTime;

        //Debug.Log("Modified Impulse:   " + playerData.finalVelocity);

        Jump(playerData.longJumpTime);
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;
        Debug.Log(player.velocity);


    }
}
