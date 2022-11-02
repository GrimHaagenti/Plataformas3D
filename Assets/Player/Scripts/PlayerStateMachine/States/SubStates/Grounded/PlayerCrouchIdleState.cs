using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (inputAxis != Vector2.zero)
        {
            stateMachine.ChangeState(player.CrouchMoveState);
        }
        if (!crouching)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        playerData.finalVelocity.x = 0f;
        playerData.finalVelocity.z = 0f;

        player.SetVelocity();


    }
}
