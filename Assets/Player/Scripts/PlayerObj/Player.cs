using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Camera camera;
    public CharacterController Controller { get; private set; }


    [SerializeField]
    GameObject ragdoll;
    public bool isDead { get; private set; }
    InputManager inputManager;
    #region STATE MACHINE
    public PlayerStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    //CAPPY
    [SerializeField]
    private GameObject Cappy;
    [SerializeField]
    private GameObject cappyInstancePoint;

    private GameObject cappyInstance;

    //SCORE
    public int coinScore { get; private set; }

    
    #region PlayerStates
    //Interact
    public PlayerSpringJumpState SpringJumpState { get; private set; }

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
    public PlayerWallJumpState wallJumpState { get; private set; }


    //TOUCHING WALL
    public PlayerWallSlideState wallSlideState { get; private set; }

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
        setRigidBodyState(true);
        setColliderState(false);
        isDead = false;
        coinScore = 0;
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
        wallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallslide");
        wallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "walljump");
        SpringJumpState = new PlayerSpringJumpState(this, StateMachine, playerData, "jump");
    }
    void Start()
    {
        playerData.wallLand = false;
        playerData.wallStay = false;
        playerData.wallExit = false;

        Controller = GetComponent<CharacterController>();

        CalculateJumpForces();

        StateMachine.Initialize(IdleState);


    }

    public void AddCoin()
    {
        coinScore++;
    }

    private void CalculateJumpForces()
    {
        playerData.normalJumpForce = 2*playerData.normalJumpDistance / playerData.normalJumpTime;
        playerData.doubleJumpForce = 2*  playerData.doubleJumpDistance / playerData.doubleJumpTime;
        playerData.tripleJumpForce =2* playerData.tripleJumpDistance / playerData.tripleJumpTime;
        playerData.backflipJumpForce = 2*playerData.backflipJumpDistance / playerData.backflipJumpTime;
        playerData.longJumpForce = 2*playerData.longJumpDistance / playerData.longJumpTime;
        playerData.wallJumpForce = 2*playerData.wallJumpDistance / playerData.wallJumpTime;
        playerData.springJumpForce = 2*playerData.springJumpDistance / playerData.springJumpTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            StateMachine.CurrentState.LogicUpdate();
            inputAxis = InputManager._INPUT_MANAGER.GetLeftAxisValue();
            if (InputManager._INPUT_MANAGER.GetCappyButtonPressed())
            {

                cappyInstance = Instantiate(Cappy, cappyInstancePoint.transform.position, Quaternion.identity, cappyInstancePoint.transform);
            }
            //Debug.Log("Applied Impulse:   " + playerData.finalVelocity);

            Controller.Move(playerData.finalVelocity * Time.deltaTime);
        }

    }
    public void Kill() 
    {
        Anim.enabled = false;
        Controller.enabled = false;
        setRigidBodyState(false);

        setColliderState(true);
        isDead = true;
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = ragdoll.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            if (state ==false)
            {
                rigidbody.AddForceAtPosition(rigidbody.transform.forward * 200f,rigidbody.position);
            }
            rigidbody.isKinematic = state;
            

        }

    }
    void setColliderState(bool state)
    {
        Collider[] colliders = ragdoll.GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }


    public void MakeSpringJump()
    {
        StateMachine.ChangeState(jumpState);
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
