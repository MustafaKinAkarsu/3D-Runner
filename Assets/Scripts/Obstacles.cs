using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles instance;
    public GameObject[] obstacles;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }
}
