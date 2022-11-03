using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector3 velocity = Vector3.zero;
    protected bool crouching;
    protected bool jumpInput;
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        playerData.alreadyJumped = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        crouching = InputManager._INPUT_MANAGER.GetCrouchButtonIsPressed();
        jumpInput = InputManager._INPUT_MANAGER.GetJumpButtonIsPressed();

        
        direction.y = -1f;


        if (player.Controller.isGrounded)
        {

            velocity.y = -1f * playerData.gravity * Time.deltaTime;
            playerData.coyoteTime = 1f;
        }
        else
        {
            stateMachine.ChangeState(player.onAirState);
        }
        playerData.finalVelocity = velocity;

    }
    public override void Exit()
    {
        base.Exit();
    }

}
