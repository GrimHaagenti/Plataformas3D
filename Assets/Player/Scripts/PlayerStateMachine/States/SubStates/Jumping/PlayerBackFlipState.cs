using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackFlipState : PlayerJumpingState
{

    protected Vector3 currentPosition;
    protected Vector3 goalPosition;
    public PlayerBackFlipState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
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


        playerData.finalVelocity = Vector3.Lerp(player.gameObject.transform.position, -player.gameObject.transform.forward * playerData.backflipDisplacementDistance, playerData.backflipJumpTime/Time.deltaTime)*Time.deltaTime;
        yVelocity = playerData.backflipJumpForce * Time.deltaTime;
        playerData.finalVelocity.y = yVelocity;
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= playerData.backflipJumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }
    }
}
