using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour,IBuffDebuffManager
    {
    [SerializeField]
    FreezeDebuff freeze;
    [SerializeField] CoinManager coinManager;
    public void Activate()
    {
        if(coinManager.coin >= freeze.cost)
        {
            freeze.isFreezed = true;
            coinManager.coin = coinManager.coin - freeze.cost;
            coinManager.CoinUpdate();
            Stop();
            StartCoroutine(DisableAfterDuration(freeze.duration));
        }
        
    }
    public IEnumerator DisableAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        freeze.isFreezed = false;
        Continue();

    }
    void Stop()
    {
        for (int i = 0; i < GameManager.instance.Runner.Length; i++)
        {
            if (GameManager.instance.Runner[i].name != "Player")
            {
                GameManager.instance.Runner[i].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = freeze.speed;
            }
        }
    }
    void Continue()
    {
        for (int i = 0; i < GameManager.instance.Runner.Length; i++)
        {
            if (GameManager.instance.Runner[i].name != "Player")
            {
                GameManager.instance.Runner[i].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = GameManager.instance.InitialSpeed;
            }
        }
    }
}
