using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    Camera cam;

    [SerializeField]
    GameObject player;
    [SerializeField]
    float distanceToPlayer = 2;


    float cameraLerp = 12;
    Vector3 dir;

    private float rotationX;
    private float rotationY;
    private void Awake()
    {
        cam = GetComponent<Camera>(); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
    }

    private void LateUpdate()
    {
        rotationX += Input.GetAxis("Mouse Y"); 
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, -50f, 50f);
        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        float smoothFactor = cameraLerp * Time.deltaTime;
        
        Vector3 finalPosition =  Vector3.Lerp(transform.position, player.transform.position - transform.forward * distanceToPlayer, smoothFactor); ;

        
        RaycastHit hit; 
        
        if (Physics.Linecast(player.transform.position, finalPosition, out hit)) { finalPosition = hit.point; }
        transform.position = finalPosition;
    }
}
