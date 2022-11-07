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
        playerData.finalVelocity = (-player.gameObject.transform.forward * playerData.backflipDisplacementDistance * playerData.normalJumpForce/2) * Time.deltaTime;
        yVelocity = playerData.backflipJumpForce ;

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


        //playerData.finalVelocity = Vector3.Lerp(player.gameObject.transform.position, -player.gameObject.transform.forward * playerData.backflipDisplacementDistance, playerData.backflipJumpTime/Time.deltaTime)*Time.deltaTime;
        //MoveCharacter(playerData.runningMaxSpeed);
        Jump(playerData.backflipJumpTime);
        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;



    }
}
