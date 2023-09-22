using UnityEngine;

[CreateAssetMenu(fileName = "BuffDebuffScriptableObject", menuName = "ScriptableObjects/Buff-Debuff")]
public class BuffDebuffScriptableObject : ScriptableObject
{
    public string buffName;
    public float duration;
    public int cost;
}
