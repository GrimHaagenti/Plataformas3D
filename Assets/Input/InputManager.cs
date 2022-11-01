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
    private bool CrouchButtonPressed = false;
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
            playerInputs.Character.Move.performed += LeftAxisUpdate;
            playerInputs.Character.Crouch.performed += IsCrouchButtonPressed;
            playerInputs.Character.Crouch.canceled += IsCrouchButtonReleased;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        mousePosition = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        

        InputSystem.Update();
    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceJumpPressed = 0f; 
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
}
