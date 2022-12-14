using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    public PlayerCrouchMoveState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        yVelocity = 0;
        playerData.finalVelocity = Vector3.zero;
    }

    public override void LogicUpdate()
    {
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;
        base.LogicUpdate();
        
        if (inputAxis == Vector2.zero)
        {
            stateMachine.ChangeState(player.CrouchIdleState);
        }
        if (!crouching)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        if (jumpInput && inputAxis.y < 0)
        {
            stateMachine.ChangeState(player.blackflipState);
        }
        if (jumpInput && inputAxis.y > 0)
        {
            stateMachine.ChangeState(player.longJumpState);
        }
        else
        {
            MoveCharacter(playerData.crouchingMaxSpeed);
        }
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;
        
       
    }
}
