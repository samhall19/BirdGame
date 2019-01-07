using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour 
{
    public Text coinAmountText;
    public Text endGameCoins;
    int coins = 0;

    public void AddCoin() 
	{
        //Add 1 coin and update text
        coins++;
        coinAmountText.text = "Coins: " + coins;
        endGameCoins.text = "Coins: " + coins;
    }
}
