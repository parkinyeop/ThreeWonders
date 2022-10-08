using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{

    int targetScore = default;
    int increaseScore = 1;
    float currentScore = 0;
    public int increaseInterval = 5;
    TextMeshProUGUI scoreText;

    //ScorePointer scoreScript;

    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        //GameObject scorePointer = FindObjectOfType<ScorePointer>().gameObject;
        //scoreScript.onScoreChange += SetScore;
    }
    void Update()
    {
        increaseScore = targetScore / increaseInterval;
        currentScore += increaseScore * Time.deltaTime;

        currentScore = Mathf.Min(currentScore, targetScore);
       
        scoreText.text = Convert.ToInt32(currentScore).ToString();
    }

    public void SetScore(int score)
    {
        targetScore += score;
    }
}
