using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerJumpingState
{

    protected Vector3 forwardReversed;
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
        
        yVelocity = playerData.wallJumpForce;
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

        if (InputManager._INPUT_MANAGER.GetJumpButtonIsReleased())
        {
            stateMachine.ChangeState(player.onAirState);
        }
        //playerData.finalVelocity = -player.gameObject.transform.forward * playerData.runningVelocity ;

        MoveCharacter(0);


        yVelocity -= playerData.gravity * Time.deltaTime;
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;


        forwardReversed.x = -player.gameObject.transform.forward.x;
        forwardReversed.z = -player.gameObject.transform.forward.z;

        forwardReversed *= playerData.wallJumpForce;

        playerData.finalVelocity.x = forwardReversed.x;
        playerData.finalVelocity.z = forwardReversed.z;
        playerData.finalVelocity.y = yVelocity;

        jumpTimer += Time.deltaTime;

        if (jumpTimer >= playerData.wallJumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }
    }
}
