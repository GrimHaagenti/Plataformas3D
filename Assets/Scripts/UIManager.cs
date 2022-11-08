using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    float currentScore;
    float maxScore;
    string scoreString = "Coins: ";
    string currentCoins = "00";
    string maxCoins = "/10";

    void Start()
    {
        currentScore = player.coinScore;
        maxScore = coinCollection.GetComponentsInChildren<CoinScript>().Length;

    }

    // Update is called once per frame
    void Update()
    {
        currentScore = player.coinScore;

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
            loseCard.SetActive(true); }
    }
}
