using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Vector3 constantRotation = new Vector3(0f, 2f, 0f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(constantRotation);
    }
}
