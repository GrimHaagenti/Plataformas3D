using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected Animator Anim;

    //Movement
    protected Vector3 direction;
    protected Vector2 inputAxis;
    static Vector3 velocityCalc = Vector3.zero;


    //JUMP
    protected float timeToPeak = 1f;
    protected float jumpTimer = 0;
    protected float yVelocity = 0f;



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
        //Debug.Log("Entering " + this.animBoolName + " state");

    }

    public virtual void Exit()
    {
        Anim.SetBool(animBoolName, false);
       // Debug.Log("Exiting " + this.animBoolName + " state");

    }
    public virtual void LogicUpdate()
    {
        inputAxis = InputManager._INPUT_MANAGER.GetLeftAxisValue();

        direction = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f) * new Vector3(inputAxis.x, 0f, inputAxis.y);
        direction.Normalize();
        


    }
    public void MoveCharacter(float max_speed)
    {
        //player.transform.rotation = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f);
        playerData.currentAccel +=playerData.accel;
        if(playerData.currentAccel > max_speed) { playerData.currentAccel = max_speed; }

        velocityCalc.x = (direction.x * playerData.currentAccel);
        velocityCalc.z = (direction.z * playerData.currentAccel);

        playerData.finalVelocity.x = velocityCalc.x;
        playerData.finalVelocity.z = velocityCalc.z;

        float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(player.gameObject.transform.eulerAngles.y, targetRotation, ref playerData.turnSmoothSpeed, playerData.turnSmoothTime);
        if (inputAxis != Vector2.zero) { player.gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f); }
        //Debug.Log(animBoolName);

    }

    public void Deacelerate()
    {
        //player.transform.rotation = Quaternion.Euler(0f, player.camera.transform.eulerAngles.y, 0f);
        playerData.currentAccel -= playerData.deaccel;
        playerData.currentAccel = Mathf.Max(playerData.currentAccel, 0);
        

        velocityCalc.x = playerData.lastXInput * playerData.currentAccel;
        velocityCalc.z = playerData.lastYInput * playerData.currentAccel;
        playerData.finalVelocity.x = velocityCalc.x;
        playerData.finalVelocity.z = velocityCalc.z;
        
    }

    protected void Jump(float jumpTime)
    {


        yVelocity -= jumpTimer;

        playerData.finalVelocity.y = yVelocity;

        jumpTimer += ((playerData.max_fallSpeed/jumpTime)*(playerData.gravity*Time.deltaTime)) * Time.deltaTime;

        


    }

}
 

