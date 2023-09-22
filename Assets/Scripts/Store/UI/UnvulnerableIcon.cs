using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UnvulnerableIcon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] UnvulnerableBuff unvulnerable; // Look for a better way to get freeze
    public void Description()
    {
        descriptionText.text = string.Format("Become untouchable for {0} seconds. It costs 10 golds.", unvulnerable.duration);
    }
}
