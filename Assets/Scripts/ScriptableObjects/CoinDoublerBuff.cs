
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/CoinDoublerBuff")]
public class CoinDoublerBuff : BuffDebuffScriptableObject
{
    public float coinMultiplier = 2.0f;
    public bool isActive;
}
