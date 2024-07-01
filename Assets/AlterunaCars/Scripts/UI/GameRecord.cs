using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameRecord
{
    public string PlayerID;
    public string PlayerName;
    public int TotalLaps;
    public float BestLapTime;
    public float TotalTime;
    public DateTime StartTime;
    public DateTime EndTime;
    public List<float> LapTimes = new List<float>();

    public GameRecord(string playerId, string playerName, int totalLaps)
    {
        PlayerID = playerId;
        PlayerName = playerName;
        TotalLaps = totalLaps;
        StartTime = DateTime.Now;
    }

    public void AddLapTime(float lapTime)
    {
        LapTimes.Add(lapTime);
        if (BestLapTime == 0 || lapTime < BestLapTime)
        {
            BestLapTime = lapTime;
        }
    }

    public void EndGame()
    {
        EndTime = DateTime.Now;
        TotalTime = (float)(EndTime - StartTime).TotalSeconds;
    }
}
