using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputs;
    public static InputManager _INPUT_MANAGER;

    private Vector2 leftAxisValue = Vector2.zero;
    private float timeSinceJumpPressed = 0f;
    private float timeSinceCappyPressed = 0f;
    private bool CrouchButtonPressed = false;
    private bool cappyButtonPressed = false;
    private bool jumpButtonReleased = false;


    public Vector2 mousePosition { get; private set; }

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(_INPUT_MANAGER);
        }
        else
        {

            playerInputs = new PlayerInputActions();
            playerInputs.Character.Enable();

            playerInputs.Character.Jump.performed += JumpButtonPressed;
            playerInputs.Character.Jump.canceled += JumpButtonReleased;
            playerInputs.Character.Move.performed += LeftAxisUpdate;
            playerInputs.Character.Crouch.performed += IsCrouchButtonPressed;
            playerInputs.Character.Crouch.canceled += IsCrouchButtonReleased;
            playerInputs.Character.ThrowCappy.performed += CappyButtonPressed;
            playerInputs.Character.ThrowCappy.canceled += CappyButtonReleased;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCappyPressed += Time.deltaTime;
         mousePosition = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        

        InputSystem.Update();
    }

    private void CappyButtonPressed(InputAction.CallbackContext context)
    {
        cappyButtonPressed = true;
        timeSinceCappyPressed = 0f;
    }
    private void CappyButtonReleased(InputAction.CallbackContext context)
    {
        cappyButtonPressed = false;

    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceJumpPressed = 0f;
        jumpButtonReleased = false;
    }

    private void JumpButtonReleased(InputAction.CallbackContext context)
    {
        jumpButtonReleased = true;
    }
    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
    
    }
   
    private void IsCrouchButtonPressed(InputAction.CallbackContext context)
    {
        CrouchButtonPressed = true;
    }
    private void IsCrouchButtonReleased(InputAction.CallbackContext context)
    {
        CrouchButtonPressed = false;
    }


    public bool GetCappyIsPressed()
    {
        return cappyButtonPressed;
    }


    public bool GetCappyButtonPressed()
    {
        return timeSinceCappyPressed == 0f;
    }
    public bool GetJumpButtonIsPressed()
    {
        return timeSinceJumpPressed == 0f;
    }
    public Vector2 GetLeftAxisValue()
    {
        return leftAxisValue;
    }

    public bool GetCrouchButtonIsPressed()
    {
        return CrouchButtonPressed;
    }

    public bool GetJumpButtonIsReleased()
    {
        return jumpButtonReleased;
    }
}
