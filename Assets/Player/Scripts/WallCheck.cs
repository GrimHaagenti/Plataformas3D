using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] Player player;
    private PlayerData playerData;
    private void Awake()
    {
        playerData = player.GetPlayerData();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerData.wallLand = true;
        playerData.wallStay = false;
        playerData.wallExit = false;
        Debug.Log("Touching Wall");

    }
    private void OnTriggerStay(Collider other)
    {
        playerData.wallLand = false;
        playerData.wallStay = true;
        playerData.wallExit = false;
        Debug.Log("Slide Wall");

    }
    private void OnTriggerExit(Collider other)
    {
        playerData.wallLand = false;
        playerData.wallStay = false;
        playerData.wallExit = true;
        Debug.Log("Exit Wall");

    }
}
