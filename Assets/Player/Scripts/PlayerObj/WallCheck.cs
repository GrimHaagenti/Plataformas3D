using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] Player player;
    private PlayerData playerData;

    float frontDistance = 0.00f;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector2 input;

    private void Start()
    {
        playerData = player.GetPlayerData();
    }
    private void LateUpdate()
    {
        input = InputManager._INPUT_MANAGER.GetLeftAxisValue();


        //startPoint.x = player.transform.forward.x + (frontDistance * input.y);
        //startPoint.y = gameObject.transform.position.y;
        //startPoint.z = player.transform.forward.z + (frontDistance * input.x);


        startPoint.x = player.gameObject.transform.position.x;
        startPoint.y = player.gameObject.transform.position.y + 1;
        startPoint.z = player.gameObject.transform.position.z;


        gameObject.transform.rotation = Quaternion.Euler(0f, player.transform.eulerAngles.y, 0f);

        
        RaycastHit hit;
        //if(Physics.Linecast(startPoint, this.gameObject.transform.position, out hit))
        //{
        //    Debug.Log(hit.collider.gameObject.layer);
        //}

        endPoint.x = startPoint.x + (frontDistance * input.y) + player.gameObject.transform.forward.x;
        endPoint.y = startPoint.y;
        endPoint.z = startPoint.z + (frontDistance * input.x) + player.gameObject.transform.forward.z;
        Debug.DrawRay(startPoint, endPoint - startPoint , Color.green, 0.2f);

        int layerM = (1 << 6);
        if (Physics.Linecast(startPoint, endPoint, out hit, layerM))
        {
            if (input != Vector2.zero)
            {

                playerData.wallStay = true;
                playerData.wallNormal = hit.normal;
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);

            }
            else
            {
                playerData.wallStay = false;

            }

        }

        else
        {
            playerData.wallStay = false;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(startPoint, endPoint);
    }
}