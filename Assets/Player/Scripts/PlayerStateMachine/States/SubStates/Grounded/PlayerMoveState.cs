using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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


        if (inputAxis == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (crouching)
        {
            stateMachine.ChangeState(player.CrouchMoveState);
        }
        if (jumpInput)
        {
            stateMachine.ChangeState(player.jumpState);
        }

        

        MoveCharacter(playerData.runningMaxSpeed);
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;


        




    }
}
