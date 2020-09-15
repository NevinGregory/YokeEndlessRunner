using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{

    public TextMeshProUGUI coinText, finalScoreText, tackledScore, distanceScore;

    void Start()
    {
        SceneMan.PrintData();

        coinText.SetText("Coins: " + SceneMan.coin);
        distanceScore.SetText("Distance: " + SceneMan.runningScore.ToString("F1"));
        tackledScore.SetText("Tackled: " + SceneMan.tackled);
        finalScoreText.SetText("Final Score: " + SceneMan.score.ToString("F1"));
    }

    void Update()
    {
        
    }
}
