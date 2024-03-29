﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreboard();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreboard();
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int newScore)
    {
        score = newScore;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreboard();
    }

    public void UpdateScoreboard()
    {
        scoreText.text = score.ToString();
    }

}
