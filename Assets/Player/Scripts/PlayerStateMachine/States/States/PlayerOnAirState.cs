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
        base.LogicUpdate();

        if (player.Controller.isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }


        
        ySpeed += ySpeed * playerData.gravity * Time.deltaTime;
        playerData.coyoteTime -= Time.deltaTime;
        if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed() && playerData.coyoteTime >= 0f)
        {

            //TO IMPLEMENT COYOTE JUMP
            stateMachine.ChangeState(player.jumpState);
        }
            
        if (ySpeed >= playerData.max_fallSpeed) { ySpeed = playerData.max_fallSpeed; }

        playerData.finalVelocity.y = ySpeed;
        //player.SetVelocity();
    }
}
