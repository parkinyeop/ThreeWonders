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
    int bestScoe;
    TextMeshProUGUI bestScoreText;
    CanvasGroup canvasGroup;
    Score score;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        restartButton = transform.GetChild(2).GetComponent<Button>();
        restartButton.onClick.AddListener(OnClickRestartButton);
        GameObject scoreObj = GameObject.FindWithTag("Score");
        score = scoreObj.GetComponent<Score>();
        bestScoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        RunPlayerController player = FindObjectOfType<RunPlayerController>();

        player.PlayerDie += Open;
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Open()
    {
        LoadData();

        StartCoroutine(DelayPanel());
    }

    IEnumerator DelayPanel()
    {
        yield return new WaitForSeconds(1f);
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        if (score.isNew)
        {
            bestScoreText.text = $"New Best Score : {bestScoe}";
            Debug.Log(score.isNew);
        }
        else
        {
            bestScoreText.text = $"Best Score : {bestScoe}";
        }

    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadData()
    {
        string path = $"{Application.dataPath}/Save/";
        string fullPath = $"{path}data.json";

        if (Directory.Exists(path) && File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestScoe = saveData.BestScore;
        }
        else
        {
            {
                bestScoe = score.bestScore;
            }
        }

    }
}
