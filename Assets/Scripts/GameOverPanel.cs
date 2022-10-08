using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverPanel : MonoBehaviour
{
    Button restartButton;
    int bestScore;
    TextMeshProUGUI bestScoreText;
    CanvasGroup canvasGroup;
    GameManager gameManager;
    Score score;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        restartButton = transform.GetChild(2).GetComponent<Button>();
        restartButton.onClick.AddListener(OnClickRestartButton);
        bestScoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        GameObject scoreObj = GameObject.FindWithTag("Score");
        score = scoreObj.GetComponent<Score>();
        
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += Open;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Open()
    {
        gameManager.LoadData();

        StartCoroutine(DelayOpenPanel());
    }

    IEnumerator DelayOpenPanel()
    {
        yield return new WaitForSeconds(1f);
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        if (score.isNew)
        {
            bestScoreText.text = $"New Best Score : {gameManager.bestScore}";
            Debug.Log($"GameoverPanel: {score.isNew}");
        }
        else
        {
            bestScoreText.text = $"Best Score : {gameManager.bestScore}";
        }

    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
