using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameRecordManager : MonoBehaviour
{
    private List<GameRecord> gameRecords = new List<GameRecord>();
    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "gameRecords.json");
        LoadRecords();
    }

    public void AddRecord(GameRecord record)
    {
        gameRecords.Add(record);
        SaveRecords();
    }

    private void SaveRecords()
    {
        var json = JsonUtility.ToJson(new GameRecordListWrapper { Records = gameRecords }, true);
        File.WriteAllText(filePath, json);
    }

    private void LoadRecords()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var wrapper = JsonUtility.FromJson<GameRecordListWrapper>(json);
            gameRecords = wrapper.Records;
        }
    }

    [Serializable]
    private class GameRecordListWrapper
    {
        public List<GameRecord> Records;
    }
}
