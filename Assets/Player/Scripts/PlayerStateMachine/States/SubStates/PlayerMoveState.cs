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
        base.LogicUpdate();

        if (inputAxis == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }


        player.transform.rotation = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f);
        playerData.finalVelocity.x = direction.x * playerData.velocityXZ;
        playerData.finalVelocity.z = direction.z * playerData.velocityXZ;
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;
        player.SetVelocity();


        




    }
}
