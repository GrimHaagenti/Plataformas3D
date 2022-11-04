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
        playerData.finalVelocity.y = -1f * playerData.gravity * Time.deltaTime;
        playerData.coyoteTime = 1f;

        if (Time.time - startTime > playerData.maxTimeToAdvanceJump)
        {
            playerData.currentJump = PlayerData.JumpsEnum._NO_JUMP;
        }

        if (!player.Controller.isGrounded)
        {
            stateMachine.ChangeState(player.onAirState);
        }







    }
    public override void Exit()
    {
        base.Exit();
    }

}
