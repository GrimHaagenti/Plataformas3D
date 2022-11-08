using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionScript : MonoBehaviour
{
    [SerializeField]
    GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Player>().AddCoin();
            Destroy(parent);
        }   
    }


}
