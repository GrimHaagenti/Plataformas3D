using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerState
{
    protected float ySpeed = 0;
    public PlayerOnAirState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        ySpeed = -1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;

        base.LogicUpdate();

        if (player.Controller.isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }

        if (playerData.wallStay && inputAxis != Vector2.zero) 
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
       
        ySpeed += ySpeed * playerData.gravity * Time.deltaTime;
        playerData.coyoteTime -= Time.deltaTime;
        if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed() && playerData.coyoteTime >= 0f)
        {
            if (!playerData.alreadyJumped)
            {
                stateMachine.ChangeState(player.jumpState);

            }
        }
        //playerData.finalVelocity.x = playerData.finalVelocity.x + (direction.x * playerData.runningVelocity * Time.deltaTime);
        //playerData.finalVelocity.z = playerData.finalVelocity.z + (direction.z * playerData.runningVelocity * Time.deltaTime);
        MoveCharacter(0);
        if (ySpeed <= -playerData.max_fallSpeed) { ySpeed = -playerData.max_fallSpeed; }
        playerData.finalVelocity.y = ySpeed;
    }
}
