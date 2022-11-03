using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.finalVelocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.Controller.isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }
        if (!playerData.wallStay || inputAxis == Vector2.zero)
        {
            stateMachine.ChangeState(player.onAirState);

        }
        
        if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed())
        {
            stateMachine.ChangeState(player.wallJumpState);
        }

        playerData.finalVelocity.y += -1f * (playerData.wallSlideGravity) * Time.deltaTime;

    }
}
