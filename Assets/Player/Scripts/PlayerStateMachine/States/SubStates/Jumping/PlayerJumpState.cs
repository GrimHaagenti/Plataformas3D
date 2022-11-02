using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerJumpingState
{

    
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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

        if(jumpTimer >= timeToPeak || InputManager._INPUT_MANAGER.GetJumpButtonIsReleased() )
        {
            jumpTimer = 0;
            stateMachine.ChangeState(player.onAirState);
            
        }
        else
        {
            yVelocity = playerData.jumpForce;
            jumpTimer += Time.deltaTime;
        }

        playerData.finalVelocity.y = yVelocity;
    }
}
