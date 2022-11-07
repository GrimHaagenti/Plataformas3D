using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerState
{
    protected float ySpeed = 0;
    Vector2 newSpeed = Vector2.zero;

    public PlayerOnAirState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName) : base(_player, _stateMachine, _playerData, _animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
        ySpeed = yVelocity;
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

        

        if (player.Controller.isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }
         if (playerData.wallStay) 
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
       
      
        ySpeed -= playerData.gravity * Time.deltaTime;
        playerData.coyoteTime -= Time.deltaTime;
        if (InputManager._INPUT_MANAGER.GetJumpButtonIsPressed() && playerData.coyoteTime >= 0f)
        {
            if (!playerData.alreadyJumped)
            {
                stateMachine.ChangeState(player.jumpState);

            }
        }
        //playerData.finalVelocity.x = playerData.finalVelocity.x + (direction.x * playerData.runningVelocity * Time.deltaTime);
        //playerData.finalVelocity.z = playerData.finalVelocity.z + (direction.z * playerData.runningVelocity * Time.deltaTime);
        //MoveCharacter(playerData.OnAirMaxSpeed);

        playerData.finalVelocity.x += direction.x ;
        playerData.finalVelocity.z += direction.z ;
        playerData.finalVelocity.x = Mathf.Lerp(playerData.finalVelocity.x, 0, playerData.airFriction * Time.deltaTime);
        playerData.finalVelocity.z = Mathf.Lerp(playerData.finalVelocity.z, 0, playerData.airFriction * Time.deltaTime);
        float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(player.gameObject.transform.eulerAngles.y, targetRotation, ref playerData.turnSmoothSpeed, playerData.turnSmoothTime);
        if (inputAxis != Vector2.zero) { player.gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f); }



        if (ySpeed <= -playerData.max_fallSpeed) { ySpeed = -playerData.max_fallSpeed; }
        playerData.finalVelocity.y = ySpeed;

        player.velocity = new Vector3(playerData.finalVelocity.x, 0, playerData.finalVelocity.z).magnitude;

    }
}
