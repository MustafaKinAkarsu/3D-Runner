using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FreezeIcon : MonoBehaviour, IDescription
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] FreezeDebuff freeze; // Look for a better way to get freeze
    public void Description()
    {
        descriptionText.text = string.Format("Freeze your opponents for {0} seconds. It costs 20 golds.", freeze.duration);
    }
}
