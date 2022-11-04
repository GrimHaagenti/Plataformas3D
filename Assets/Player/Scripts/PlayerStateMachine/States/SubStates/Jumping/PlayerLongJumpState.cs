using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLongJumpState : PlayerJumpingState
{
    public PlayerLongJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;
        base.LogicUpdate();

        yVelocity = playerData.longJumpForce ;
        playerData.finalVelocity = player.gameObject.transform.forward * playerData.runningVelocity*2;
        MoveCharacter(0);
        playerData.finalVelocity.y = yVelocity;
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= playerData.longJumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }
    }
}
