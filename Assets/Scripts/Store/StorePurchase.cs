using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePurchase : MonoBehaviour
{

    [SerializeField] CoinDoubler coinDoubler;
    [SerializeField] Unvulnerable unvulnerable;
    [SerializeField] Freeze freeze;
    [SerializeField] GameObject player;
    public GameObject storeCanvas;

    public void FreezePurchased()
    {
        freeze.Activate();
        player.GetComponent<PathCreation.Examples.PathFollower>().enabled = true;
        storeCanvas.SetActive(false);
    }
    public void CoinPurchased()
    {
        coinDoubler.Activate();
        player.GetComponent<PathCreation.Examples.PathFollower>().enabled = true;
        storeCanvas.SetActive(false);
    }
    public void UnvulnerablePurchased()
    {
        unvulnerable.Activate();
        player.GetComponent<PathCreation.Examples.PathFollower>().enabled = true;
        storeCanvas.SetActive(false);
    }
}
