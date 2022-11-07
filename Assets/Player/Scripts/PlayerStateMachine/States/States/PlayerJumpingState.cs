using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    

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
        jumpTimer = 0;
        playerData.alreadyJumped = true;
        playerData.finalVelocity.y = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        jumpTimer = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //if (stateMachine.CurrentState != player.longJumpState)
        //{
            if (playerData.finalVelocity.y < -1)
            {
                stateMachine.ChangeState(player.onAirState);
            }
        
        
    }
}
