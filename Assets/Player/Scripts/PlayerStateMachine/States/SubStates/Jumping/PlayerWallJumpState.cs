using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerJumpingState
{

    protected Vector3 wallJumpVector;
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

        playerData.finalVelocity = -player.transform.forward * playerData.wallJumpForce;
        yVelocity = playerData.wallJumpForce;
        Debug.Log("Impulse:   " + playerData.finalVelocity);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        playerData.lastXInput = direction.x;
        playerData.lastYInput = direction.z;
        Debug.Log("Should Applied Impulse:   " + playerData.finalVelocity);
         
        base.LogicUpdate();

        if (InputManager._INPUT_MANAGER.GetJumpButtonIsReleased())
        {
            stateMachine.ChangeState(player.onAirState);
        }
        //playerData.finalVelocity = -player.gameObject.transform.forward * playerData.runningVelocity ;

        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;
        Jump(playerData.wallJumpTime);


        
    }
}
