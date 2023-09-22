using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinIcon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] CoinDoublerBuff coin; // Look for a better way to get freeze
    public void Description()
    {
        descriptionText.text = string.Format("Double the amount of coins received for {0} seconds. It costs 30 golds.", coin.duration);
    }
}
