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
        yVelocity = 0;
    }

    public override void Exit()
    {
        base.Exit();
        yVelocity = 0;
        playerData.finalVelocity.y = 0f ;
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();
        if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed())
        {
            stateMachine.ChangeState(player.wallJumpState);
        }
        if (player.isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }
        if (!playerData.wallStay)
        {
            stateMachine.ChangeState(player.onAirState);

        }


        yVelocity += -1f * (playerData.wallSlideGravity) * Time.deltaTime;
        yVelocity = Mathf.Min(yVelocity, playerData.wallslideMaxSpeed);
        playerData.finalVelocity.y = yVelocity;
        playerData.finalVelocity.z = 0f;
    }
}
