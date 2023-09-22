using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unvulnerable : MonoBehaviour,IBuffDebuffManager
{
    [SerializeField]
    UnvulnerableBuff unvulnerable;
    [SerializeField] CoinManager coinManager;
    public void Activate()
    {
        if (coinManager.coin >= unvulnerable.cost)
        {
            unvulnerable.isUnvulnerable = true;
            coinManager.coin = coinManager.coin - unvulnerable.cost;
            coinManager.CoinUpdate();
            ColliderFalse();
            StartCoroutine(DisableAfterDuration(unvulnerable.duration));
        }
    }
    public IEnumerator DisableAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        unvulnerable.isUnvulnerable = false;
        ColliderTrue();

    }
    void ColliderTrue()
    {
        foreach (GameObject obstacle in Obstacles.instance.obstacles)
        {
            Collider obstacleCollider = obstacle.GetComponent<Collider>();
            if (obstacleCollider != null)
            {
                Physics.IgnoreCollision(GameManager.instance.Player.GetComponent<Collider>(), obstacleCollider, false);
            }
        }
    }
    void ColliderFalse()
    {
        foreach (GameObject obstacle in Obstacles.instance.obstacles)
        {
            Collider obstacleCollider = obstacle.GetComponent<Collider>();
            if (obstacleCollider != null)
            {
                Physics.IgnoreCollision(GameManager.instance.Player.GetComponent<Collider>(), obstacleCollider, true);
            }
        }
    }

}
