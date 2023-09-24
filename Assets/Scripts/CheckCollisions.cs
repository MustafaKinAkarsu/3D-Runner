using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckCollisions : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;


    // Added new codes
    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;
    private InGameRanking ig;
    [SerializeField]
    private CoinDoublerBuff coinDoubler;
    [SerializeField] private UnvulnerableBuff unvulnerable;
    PathCreation.Examples.PathFollower pathFollower;
    StorePurchase storeScript;
    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        pathFollower = playerController.Player.GetComponent<PathCreation.Examples.PathFollower>();
        ig = FindObjectOfType<InGameRanking>();
        storeScript = GameObject.Find("GameManager").GetComponent<StorePurchase>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if(coinDoubler.isActive) DoubleCoins();

            else AddCoin();

            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            PlayerFinished();
            if (ig.namesTxt[6].text == "Player")
            {
                Debug.Log("Congrats!..");
            }
            else
            {
                Debug.Log("You Lose!..");
            }
            
        }
        else if (other.CompareTag("Speedboost"))
        {
            playerController.runningSpeed = playerController.runningSpeed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
        else if (other.CompareTag("Entrance")) // User's Path Following script is enabled to take the store path.
        {
            if(playerController.Player.GetComponent<PathCreation.Examples.PathFollower>() == null) playerController.Player.AddComponent<PathCreation.Examples.PathFollower>();
            if(pathFollower == null) pathFollower = playerController.Player.GetComponent<PathCreation.Examples.PathFollower>();
            if (pathFollower.pathCreator == null) 
            {
                pathFollower.pathCreator = GameObject.Find("Path").GetComponent<PathCreation.PathCreator>();
                pathFollower.playerController = playerController.GetComponent<PlayerController>();
            }    
            pathFollower.enabled = true;
        }
        else if (other.CompareTag("StorePoint")) // User's movement script disabled to stop the user in front of the store
        {
            pathFollower.enabled = false;
            playerController.enabled = false;
            storeScript.storeCanvas.SetActive(true);
        }
        
        else if (other.CompareTag("Exit"))
        {
            playerController.enabled = true;
            Destroy(pathFollower);
            playerController.Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void DoubleCoins()
    {
        coinManager.coin += 2;
        coinManager.CoinUpdate();
    }

    void PlayerFinished() {
        playerController.runningSpeed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {       
           transform.position = PlayerStartPos;                   
    }

    public void AddCoin()
    {
        coinManager.coin++;
        coinManager.CoinUpdate();
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }
   

}
