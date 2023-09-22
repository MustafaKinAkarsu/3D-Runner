using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public TextMeshProUGUI CoinText;

    public void CoinUpdate()
    {
        CoinText.text = "Coin: " + coin.ToString();
    }
}
