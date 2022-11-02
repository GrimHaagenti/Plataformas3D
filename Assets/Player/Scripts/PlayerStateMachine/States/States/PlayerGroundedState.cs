using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 inputAxis;
    protected Vector3 direction;
    protected Vector3 velocity = Vector3.zero;
    protected bool crouching;
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        inputAxis = InputManager._INPUT_MANAGER.GetLeftAxisValue();
        crouching = InputManager._INPUT_MANAGER.GetCrouchButtonIsPressed();

        direction = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f) * new Vector3(inputAxis.x, 0f, inputAxis.y);
        direction.Normalize();
        direction.y = -1f;


        if (player.Controller.isGrounded)
        {

            if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed())
            {
                stateMachine.ChangeState(player.jumpState);
            }
            else
            {
                velocity.y = -1f * playerData.gravity * Time.deltaTime;
                playerData.coyoteTime = 1f;
            }
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
