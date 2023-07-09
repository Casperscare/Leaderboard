using UnityEngine;
using UnityEngine.UI;

public class ScoreboardUIManager : MonoBehaviour
{
    public GameObject playerStatPrefab;
    public Transform scoreboardContent;
    public LeaderboardManager leaderboardManager;

    public void PopulateScoreboard()
    {
        // Clear existing entries
        foreach (Transform child in scoreboardContent)
        {
            Destroy(child.gameObject);
        }

        // Check if leaderboardManager is assigned
        if (leaderboardManager == null)
        {
            Debug.LogError("LeaderboardManager reference is missing!");
            return;
        }

        // Clone the playerStatPrefab for each entry in the scoreboard
        foreach (LeaderboardEntry entry in leaderboardManager.leaderboardEntries)
        {
            GameObject playerStatInstance = Instantiate(playerStatPrefab, scoreboardContent);
            PlayerStatUI playerStatUI = playerStatInstance.GetComponent<PlayerStatUI>();
            playerStatUI.SetPlayerStats(entry.playerName, entry.timeTaken);
        }
    }
    void Start()
    {
        // Assuming you have a reference to the ScoreboardUIManager
PopulateScoreboard();

    }
}
