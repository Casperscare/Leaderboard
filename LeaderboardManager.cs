using System.Net.Mime;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    public List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
    public string filePath;

    private void Start()
    {
        LoadLeaderboardEntries();
        filePath = Application.dataPath+ "/" + filePath;
        LoadLeaderboardEntries();
        // ClearLeaderboard();
    }

    public void AddEntry(string playerName, string timeTaken)
    {
        LeaderboardEntry entry = new LeaderboardEntry
        {
            playerName = playerName,
            timeTaken = timeTaken
        };

        leaderboardEntries.Add(entry);
        SaveLeaderboardEntries();
    }

    private void LoadLeaderboardEntries()
    {
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    string playerName = parts[0];
                    string timeTaken = parts[1];

                    LeaderboardEntry entry = new LeaderboardEntry
                    {
                        playerName = playerName,
                        timeTaken = timeTaken
                    };
                    leaderboardEntries.Add(entry);
                }
            }
            reader.Close();
        }
    }

    private void SaveLeaderboardEntries()
    {
        StreamWriter writer = new StreamWriter(filePath);
        foreach (LeaderboardEntry entry in leaderboardEntries)
        {
            string line = entry.playerName + "|" + entry.timeTaken;
            writer.WriteLine(line);
        }
        writer.Close();
    }

    public void ClearLeaderboard()
{
    leaderboardEntries.Clear();
    SaveLeaderboardEntries();
    DeleteLeaderboardFile();
}

private void DeleteLeaderboardFile()
{
    if (File.Exists(filePath))
    {
        File.Delete(filePath);
    }
}
}
