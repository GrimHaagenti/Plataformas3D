using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    Player player;
    [SerializeField]
    GameObject coinCollection;
    [SerializeField]
    GameObject winCard;
    [SerializeField]
    GameObject loseCard;
    [SerializeField]
    TextMeshProUGUI respawnNumber;

    float currentScore;
    float maxScore;
    public int respawnInt;
    private float maxTimeToRespawn = 3;
    string scoreString = "Coins: ";
    string currentCoins = "00";
    string maxCoins = "/10";


    void Start()
    {
        respawnInt = (int)maxTimeToRespawn;
        currentScore = player.coinScore;
        maxScore = coinCollection.GetComponentsInChildren<CoinScript>().Length;

    }

    // Update is called once per frame
    void Update()
    {
        currentScore = player.coinScore;
        if (respawnInt <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void LateUpdate()
    {
        text.text = scoreString + currentScore.ToString() + "/" + maxScore.ToString();
        
        if (!player.isDead)
        {
            if (currentScore == maxScore)
            {
                winCard.SetActive(true);
            }
        }
        else { 
                winCard.SetActive(false);
            loseCard.SetActive(true);
            respawnInt = Mathf.CeilToInt(maxTimeToRespawn - player.timeSinceDeath);
            respawnNumber.text = respawnInt.ToString();
        }
    }
}
