using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text runningScoreText, coinScoreText;

    public float runningScore { get; set; }
    public int coinScore { get; set; }
    public int numTackled { get; set; }


    void Start()
    {
        runningScore = 0.0f;
        coinScore = 0;
    }

    void Update()
    {
        runningScore += Time.deltaTime * 0.3f;

        runningScoreText.text = (runningScore*10).ToString("F1") + " ";
        coinScoreText.text = coinScore + "   ";
    }

    public void IncreaseCoins()
    {
        coinScore++;
    }

    public void Tackled()
    {
        numTackled++;
    }

    public float CalculateScore()
    {
        return runningScore + (coinScore * 10) + (numTackled * 5);
    }
}
