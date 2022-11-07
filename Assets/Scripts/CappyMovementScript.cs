using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CappyMovementScript : MonoBehaviour
{
    [SerializeField]
    Player player;
    private float ThrowDistance = 10f;
    [SerializeField]
    private float velocity = 2f;
    Vector3 startPoint;
    private bool returning = false;
    private Vector3 endPoint = Vector3.zero;

    private void Awake()
    {
        startPoint = gameObject.transform.position;
        player = transform.parent.GetComponentInParent<Player>() ;
    }
    void Start()
    {
        endPoint = startPoint+player.gameObject.transform.forward * ThrowDistance;

    }

    void Update()
    {
        

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, velocity * Time.deltaTime);

        Debug.DrawLine(transform.position, endPoint);

        if (!InputManager._INPUT_MANAGER.GetCappyIsPressed() )
        {
            returning = true;
        }
        if (returning)
        {
            endPoint = new Vector3(player.gameObject.transform.position.x, gameObject.transform.position.y, player.gameObject.transform.position.z);
        }

        if (Vector3.Distance(gameObject.transform.position, endPoint)<1.5f && returning)
        {
            Debug.Log(Vector3.Distance(gameObject.transform.position, endPoint));
            Destroy(gameObject);
        }
        
    }
    private void OnDrawGizmos()
    {
    }
}
