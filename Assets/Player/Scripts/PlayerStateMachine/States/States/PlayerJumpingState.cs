using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    protected float timeToPeak = 1f;
    protected float jumpTimer = 0;

    protected float yVelocity = 0f;

    public PlayerJumpingState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.alreadyJumped = true;
    }

    public override void Exit()
    {
        base.Exit();
        jumpTimer = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


      

    }
}
