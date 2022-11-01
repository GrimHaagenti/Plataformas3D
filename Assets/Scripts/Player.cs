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

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    #endregion

    //MOVE
    private Vector3 playerVelocity = Vector3.zero; 
    private float velocityXZ = 2f;
    private Vector2 inputAxis;

    private float timeToMaxSpeed = 1f;
    private float MaxSpeed = 2f;
    //JUMP




    public float velocity = 0;
    Vector3 currentSpeed = Vector3.zero;


    //CROUCH
    public bool isCrouching { get; private set; }
    public bool Grounded { get; private set; }
    public bool Jumping { get; private set; }

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");

    }
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);


    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();


        if (InputManager._INPUT_MANAGER.GetCrouchButtonIsPressed())
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }


        


        Controller.Move(playerData.finalVelocity * Time.deltaTime);
        currentSpeed = playerVelocity;


    }

    public void SetVelocity() 
    {
        playerVelocity =playerData.finalVelocity;
    }
    public  float GetCurrentSpeedX()
    {
        return currentSpeed.x;
    }
    public  float GetCurrentSpeedY()
    {
        return currentSpeed.z;
    }
    public  float GetCurrentVelocity()
    {
        return velocity;
    }

}
