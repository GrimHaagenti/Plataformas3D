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
        switch (playerData.currentJump)
        {
            case PlayerData.JumpsEnum._NO_JUMP:
                
                playerData.currentJump = PlayerData.JumpsEnum.NORMALJUMP;
                yVelocity = playerData.normalJumpForce;
                break;
            case PlayerData.JumpsEnum.NORMALJUMP:

                playerData.currentJump = PlayerData.JumpsEnum.DOUBLEJUMP;
                yVelocity = playerData.doubleJumpForce;

                break;
            case PlayerData.JumpsEnum.DOUBLEJUMP:
                if (inputAxis == Vector2.zero)
                {
                    playerData.currentJump = PlayerData.JumpsEnum.NORMALJUMP;
                yVelocity = playerData.normalJumpForce;
                }
                else
                {
                    playerData.currentJump = PlayerData.JumpsEnum.TRIPLEJUMP;
                    yVelocity = playerData.tripleJumpForce;

                }
                break;
            case PlayerData.JumpsEnum.TRIPLEJUMP:
                playerData.currentJump = PlayerData.JumpsEnum.NORMALJUMP;
                yVelocity = playerData.normalJumpForce;
                break;

        }
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
        switch (playerData.currentJump)
        {
            case PlayerData.JumpsEnum.NORMALJUMP:
                Jump(playerData.normalJumpForce, playerData.normalJumpTime);

                break;
            case PlayerData.JumpsEnum.DOUBLEJUMP:
                Jump(playerData.doubleJumpForce, playerData.doubleJumpTime);

                break;
            case PlayerData.JumpsEnum.TRIPLEJUMP:
                Jump(playerData.tripleJumpForce, playerData.tripleJumpTime);
                break;  
            default:
            case PlayerData.JumpsEnum._NO_JUMP:
                break;


        }


    }



    private void Jump(float jumpForce, float jumpTime)
    {

        yVelocity -=  playerData.gravity * Time.deltaTime;

        playerData.finalVelocity.y = yVelocity;
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= jumpTime)
        {

            stateMachine.ChangeState(player.onAirState);
        }


    }
}
