using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScorePointer : MonoBehaviour
{
    GameObject scoreObj;
    Score score;
    //public Action<int> onScoreChange;

    private void Awake()
    {
        scoreObj = GameObject.FindWithTag("Score");
        score = scoreObj.GetComponent<Score>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddScore(10);
        }
    }

    void AddScore(int point)
    {
        score.SetScore(point);
    }
}
