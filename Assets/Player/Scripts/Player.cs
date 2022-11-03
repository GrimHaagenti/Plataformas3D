using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Camera camera;
    public CharacterController Controller { get; private set; }

    InputManager inputManager;
    #region STATE MACHINE
    public PlayerStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    #region PlayerStates
    
    //GROUNDED
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    //ON AIR
    public PlayerOnAirState onAirState { get; private set; }

    //JUMPING
    public PlayerJumpState jumpState { get; private set; }
    public PlayerLongJumpState longJumpState { get; private set; }
    public PlayerBackFlipState blackflipState { get; private set; }

    

    #endregion

    #endregion

    //MOVE
    private Vector3 playerVelocity = Vector3.zero; 
    private Vector2 inputAxis;

    private float timeToMaxSpeed = 1f;
    private float MaxSpeed = 2f;
    //JUMP


    public float velocity = 0;


    //CROUCH
    public bool isCrouching { get; private set; }
    public bool Grounded { get; private set; }
    public bool Jumping { get; private set; }

    private void Awake()
    {
        Anim = GetComponent<Animator>();

        StateMachine = new PlayerStateMachine();
        

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        onAirState = new PlayerOnAirState(this, StateMachine, playerData, "onAir");
        jumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        longJumpState = new PlayerLongJumpState(this, StateMachine, playerData, "longJump");
        blackflipState = new PlayerBackFlipState(this, StateMachine, playerData, "backflip");

    }
    void Start()
    {
        Controller = GetComponent<CharacterController>();

        CalculateJumpForces();

        StateMachine.Initialize(IdleState);


    }


    private void CalculateJumpForces()
    {
        playerData.normalJumpForce = 2 * playerData.normalJumpDistance / playerData.normalJumpTime;
        playerData.doubleJumpForce = 2 * playerData.doubleJumpDistance / playerData.doubleJumpTime;
        playerData.tripleJumpForce = 2 * playerData.tripleJumpDistance / playerData.tripleJumpTime;
        playerData.backflipJumpForce = 2 * playerData.backflipJumpDistance / playerData.backflipJumpTime;
        playerData.longJumpForce = 2 * playerData.longJumpDistance / playerData.longJumpTime;
    }
    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        inputAxis = InputManager._INPUT_MANAGER.GetLeftAxisValue();



        Controller.Move(playerData.finalVelocity * Time.deltaTime);


    }

    public void SetVelocity() 
    {
        //playerVelocity = playerData.finalVelocity;
    }
    public  float GetCurrentSpeedX()
    {
        return inputAxis.x;
    }
    public  float GetCurrentSpeedY()
    {
        return inputAxis.y;
    }
    public  float GetCurrentVelocity()
    {
        return velocity;
    }

}
