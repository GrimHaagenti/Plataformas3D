using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected Animator Anim;

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

    }
}

