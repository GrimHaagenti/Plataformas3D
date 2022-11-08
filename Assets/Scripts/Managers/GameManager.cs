using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    float timeSinceDeath = 0;
    float maxReloadTime = 3f;
    [SerializeField] UIManager uiManager;

    Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (player.GetComponent<Player>().isDead)
        {
            timeSinceDeath += Time.deltaTime;
            uiManager.respawnInt = Mathf.CeilToInt(maxReloadTime - timeSinceDeath);
        }

        if (timeSinceDeath >= maxReloadTime)
        {
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
