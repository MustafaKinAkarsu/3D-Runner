using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDoubler : MonoBehaviour,IBuffDebuffManager
{
    [SerializeField]
    CoinDoublerBuff coinDoubler;
    [SerializeField] CoinManager coinManager;
    public void Activate()
    {
        if(coinManager.coin >= coinDoubler.cost)
        {
            coinDoubler.isActive = true;
            coinManager.coin = coinManager.coin - coinDoubler.cost;
            coinManager.CoinUpdate();
            StartCoroutine(DisableAfterDuration(coinDoubler.duration));
        }
        
    }
    public IEnumerator DisableAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        coinDoubler.isActive = false;
    }
}
