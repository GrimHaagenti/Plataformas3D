using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;


    protected float startTime;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, PlayerData _playerData, string _animBoolName)
    {
        player = _player;
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
        startTime = Time.time;
    }
   
    public virtual void Exit()
    {

    }
    public virtual void LogicUpdate()
    {

    }
}

