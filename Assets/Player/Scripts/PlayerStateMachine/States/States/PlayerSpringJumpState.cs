using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpringJumpState : PlayerJumpingState
{
    
    public PlayerSpringJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        yVelocity = playerData.springJumpForce;
    }

    public override void Exit()
    {
        base.Exit();
        playerData.SpringJump = false;
    }

    public override void LogicUpdate()
    {
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;
        base.LogicUpdate();


        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;


      
        //MoveCharacter(playerData.runningVelocity);
        Jump(playerData.springJumpTime);
    }
}
