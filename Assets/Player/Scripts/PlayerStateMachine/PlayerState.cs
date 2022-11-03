using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected Animator Anim;


    protected Vector3 direction;
    protected Vector2 inputAxis;


    protected float startTime;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName)
    {
        player = _player;
        Anim = player.Anim;
        stateMachine = _stateMachine;
        playerData = _playerData;
        animBoolName = _animBoolName;
    }

    public virtual void DoChecks()
    {

    }
    public virtual void Enter()
    {
        DoChecks();
        Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }
   
    public virtual void Exit()
    {
        Anim.SetBool(animBoolName, false);

    }
    public virtual void LogicUpdate()
    {
        inputAxis = InputManager._INPUT_MANAGER.GetLeftAxisValue();

        direction = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f) * new Vector3(inputAxis.x, 0f, inputAxis.y);
        direction.Normalize();
    }
    public void MoveCharacter(float velocity)
    {
        player.transform.rotation = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f);
        playerData.finalVelocity.x = direction.x * velocity;
        playerData.finalVelocity.z = direction.z * velocity;
    }
}

