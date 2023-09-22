using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking ig;

    private GameObject player;
    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }
    private GameObject[] runner;
    public GameObject[] Runner
    {
        get { return runner; }
        set { runner = value; }
    }
    private float initialSpeed;
    public float InitialSpeed
    {
        get { return initialSpeed; }
        set { initialSpeed = value; }
    }
    List<RankingSystem> sortArray= new List<RankingSystem>();


    private void Awake()
    {
        instance = this;
        Player = GameObject.Find("Player");
        Runner = GameObject.FindGameObjectsWithTag("Runner");
        InitialSpeed = Runner[0].GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
        ig = FindObjectOfType<InGameRanking>();
    }

    void Start()
    {
        for (int i = 0; i < Runner.Length; i++)
        {
            sortArray.Add(Runner[i].GetComponent<RankingSystem>());
        }
    }

    //void Update()
    //{
    //    CalculateRanking();
    //}

    //void CalculateRanking()
    //{
    //    sortArray = sortArray.OrderBy(x => x.distance).ToList();
    //    sortArray[0].rank = 1;
    //    sortArray[1].rank = 2;
    //    sortArray[2].rank = 3;
    //    sortArray[3].rank = 4;
    //    sortArray[4].rank = 5;
    //    sortArray[5].rank = 6;
    //    sortArray[6].rank = 7;

    //    ig.a = sortArray[6].name;
    //    ig.b = sortArray[5].name;
    //    ig.c = sortArray[4].name;
    //    ig.d = sortArray[3].name;
    //    ig.e = sortArray[2].name;
    //    ig.f = sortArray[1].name;
    //    ig.g = sortArray[0].name;
    //}
}
