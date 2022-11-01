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


    private float cameraLerp = 12;
    private float cameraMouseSensibility = 8f;
    private float upperSmoothingThreshold = 1f;
    private float lowerSmoothingThreshold = 0.4f;
    private Vector3 lastCameraPosition = Vector3.zero;

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


        rotationX += InputManager._INPUT_MANAGER.mousePosition.y/ cameraMouseSensibility;
        rotationY += InputManager._INPUT_MANAGER.mousePosition.x/ cameraMouseSensibility;

        rotationX = Mathf.Clamp(rotationX, -50f, 50f);
        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        float smoothFactor = cameraLerp * Time.deltaTime;

        Vector3 finalPoint = player.transform.position - transform.forward * distanceToPlayer;
        Vector3 finalPosition = Vector3.zero;

        //Debug.Log(Vector3.Distance(lastCameraPosition, finalPoint));
        if (Vector3.Distance(lastCameraPosition, finalPoint ) > upperSmoothingThreshold)
        {
            finalPosition = Vector3.Lerp(transform.position, finalPoint, smoothFactor*1.5f); 
        }
        else if(Vector3.Distance(lastCameraPosition, finalPoint) > lowerSmoothingThreshold) {
            finalPosition = Vector3.Lerp(transform.position, finalPoint, smoothFactor*4f);

        }
        else
        {
            finalPosition = Vector3.Lerp(transform.position, finalPoint, smoothFactor * 7.5f); ;
        }

        RaycastHit hit; 
        
        if (Physics.Linecast(player.transform.position, finalPosition, out hit)) { finalPosition = hit.point; }
        transform.position = finalPosition;
        lastCameraPosition = transform.position;
    }
}
