using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camera;
    private CharacterController controller;


    //MOVE
    private Vector3 finalVelocity = Vector3.zero; 
    private float velocityXZ = 2f;
    //JUMP
    private float gravity = 20f; 

    private float jumpForce = 10f;

    private float coyoteTime = 1f;

    private float max_fallSpeed = 10.0f;

    private float velocity = 0;
    Vector3 currentSpeed = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
       

        direction.Normalize();


        transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        finalVelocity.x = direction.x * velocityXZ;
        finalVelocity.z = direction.z * velocityXZ;
        velocity = new Vector3(finalVelocity.x, 0 , finalVelocity.z).magnitude;

        direction.y = -1f;

       if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                finalVelocity.y = jumpForce;
            }
            else
            {
                finalVelocity.y = direction.y * gravity * Time.deltaTime;
                coyoteTime = 1f;
            }
        }
        else
        {
            finalVelocity.y += direction.y * gravity * Time.deltaTime;
            coyoteTime -= Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && coyoteTime >= 0f)
            {
                finalVelocity.y = jumpForce; coyoteTime = 0f;
            }

            if (finalVelocity.y >= max_fallSpeed) { finalVelocity.y = max_fallSpeed; } 
        }
       currentSpeed = finalVelocity;
        
        
        controller.Move(finalVelocity * Time.deltaTime);


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
