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

    private float maxStayTime = 2f;
    private float stayTimer = 0f;
    Vector3 startPoint;
    private bool returning = false;
    private Vector3 endPoint = Vector3.zero;

    private void Awake()
    {
        startPoint = gameObject.transform.position;
        player = transform.parent.GetComponentInParent<Player>() ;
        transform.parent = null;
    }
    void Start()
    {
        endPoint = startPoint+player.gameObject.transform.forward * ThrowDistance;

    }

    void Update()
    {

        gameObject.transform.Rotate(new Vector3(0f, 2f, 0f));
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, velocity * Time.deltaTime);

        if(Vector3.Distance(gameObject.transform.position, endPoint) < 0.5f )
        {
            stayTimer += Time.deltaTime;
        }

        Debug.DrawLine(transform.position, endPoint,Color.red);

        if(stayTimer >= maxStayTime) { returning = true; }

        if (!InputManager._INPUT_MANAGER.GetCappyIsPressed() )
        {
            returning = true;
        }
        if (returning)
        {
            endPoint = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y+1, player.gameObject.transform.position.z);
        }

        if (Vector3.Distance(gameObject.transform.position, endPoint) < 2f && returning)
        {
            Destroy(gameObject);
        }
        
    }
    
}
