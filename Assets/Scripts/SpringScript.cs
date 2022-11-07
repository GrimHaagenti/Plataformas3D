using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    Vector3 jump = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="Player")
        {
            Player pl = other.gameObject.GetComponent<Player>();
            pl.StateMachine.ChangeState(pl.SpringJumpState);
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.name == "Player")
        {
            Player pl = other.gameObject.GetComponent<Player>();
            if (pl.StateMachine.CurrentState != pl.SpringJumpState) { pl.StateMachine.ChangeState(pl.SpringJumpState); }
        }
    }
}
