using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject set;
    
    public float timeBetweenObstacles;
    private float timer;

    private void Awake()
    {
        timer = timeBetweenObstacles;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Instantiate(set);
            timer = timeBetweenObstacles;
        }
    }
}
