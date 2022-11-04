using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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
            stateMachine.ChangeState(player.MoveState);
        }
        if (crouching)
        {
            stateMachine.ChangeState(player.CrouchIdleState);
        }
        if (jumpInput)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        Deacelerate();

    }
}
