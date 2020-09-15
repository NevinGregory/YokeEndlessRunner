using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{

    static ScoreManager sc;

    public static float score { get; set; }
    public static float coin { get; set; }

    public static float tackled { get; set; }
    
    public static float runningScore { get; set; }

    public static SceneMan instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            sc = Camera.main.GetComponent<ScoreManager>();
        }
    }

    public static void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public static void StartMenu() {
        SceneManager.LoadScene(0);
    }

    public static void GameOver() {
        score = sc.CalculateScore();
        coin = sc.coinScore;
        //Debug.Log(sc.coinScore + " " + coin);
        tackled = sc.numTackled;
        //Debug.Log(sc.numTackled + " " + tackled);
        runningScore = sc.runningScore; 
        //Debug.Log(sc.runningScore + " " + runningScore);

        SceneManager.LoadScene(2);
    }

    public static void PrintData()
    {
        Debug.Log(coin + " " + tackled + " " + runningScore);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
