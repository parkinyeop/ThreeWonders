using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void Start()
    {
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += SaveData;
    }
    void SaveData()
    {

        if (score.isNew)
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
}


