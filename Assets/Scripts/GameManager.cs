using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    Score score;
    public int bestScore;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void Start()
    {
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += SaveData;
        LoadData();
    }
    void SaveData()
    {
        if (score.isNew == true)
        {
            SaveData saveData = new SaveData();
            saveData.BestScore = score.bestScore;
            string json = JsonUtility.ToJson(saveData);
            string path = $"{Application.dataPath}/Save/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullpath = $"{path}data.json";
            File.WriteAllText(fullpath, json);
        }
    }
    public void LoadData()
    {
        string path = $"{Application.dataPath}/Save/";
        string fullPath = $"{path}data.json";

        if (Directory.Exists(path) && File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestScore = saveData.BestScore;
        }
        else
        {
            {
                bestScore = score.bestScore;
            }
        }

    }
}


