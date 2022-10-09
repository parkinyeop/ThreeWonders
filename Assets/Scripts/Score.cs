using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{

    int targetScore = default;
    int increaseScore = 1;
    public int bestScore ;
    public float currentScore = 0;
    public int increaseInterval = 5;
    public bool isNew = false;
    TextMeshProUGUI scoreText;

    //ScorePointer scoreScript;
    private void Awake()
    {
        SaveData saveData = new SaveData();
        bestScore = saveData.BestScore;
    }
    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        isNew = false;
        
    }
    void Update()
    {
        increaseScore = targetScore / increaseInterval;
        currentScore += increaseScore * Time.deltaTime;

        currentScore = Mathf.Min(currentScore, targetScore);
       
        scoreText.text = Convert.ToInt32(currentScore).ToString();

        if (currentScore > bestScore)
        {
            bestScore = Convert.ToInt32(currentScore);
            isNew = true;
            //Debug.Log($"Score: {isNew}");
        }
        else
        {
            isNew = false;
        }
    }

    public void SetScore(int score)
    {
        targetScore += score;
    }
}
