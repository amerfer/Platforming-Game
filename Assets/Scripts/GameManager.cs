using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int currentCoin;
    public Text CoinText;

    public int currentHealth;
    public Text HeartText;
    
    //add coins to the player
    public void addCoin(int coinToAdd)
    {
        currentCoin += coinToAdd; // number coins is collected
        CoinText.text = "Coin:" + currentCoin;// display the current coin amount


    }

    public void showHearts(int HeartShow)
    {
        HeartText.text = "Heart:" + HeartShow;
    }


    
}
