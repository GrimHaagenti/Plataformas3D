using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerJumpingState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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

        if (InputManager._INPUT_MANAGER.GetJumpButtonIsReleased())
        {
            stateMachine.ChangeState(player.onAirState);
        }
        playerData.finalVelocity = -player.gameObject.transform.forward * playerData.runningVelocity ;
        //MoveCharacter(playerData.runningVelocity);
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;

        yVelocity = playerData.wallJumpForce ;
        yVelocity -= playerData.gravity * Time.deltaTime;

        playerData.finalVelocity.y = yVelocity;
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= playerData.wallJumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }
    }
}
