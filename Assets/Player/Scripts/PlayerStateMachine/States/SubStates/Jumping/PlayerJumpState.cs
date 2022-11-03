using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerJumpingState
{

    
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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

        MoveCharacter(playerData.runningVelocity); 
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;

        yVelocity = playerData.normalJumpForce * Time.deltaTime;
        playerData.finalVelocity.y = yVelocity ;
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= playerData.normalJumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }
       
           
    }
}
