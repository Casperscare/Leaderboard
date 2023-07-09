using UnityEngine;
using TMPro;

public class PlayerStatUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text scoreText;

    public void SetPlayerStats(string playerName, string score)
    {
        nameText.text = playerName;
        scoreText.text = score;
    }
}
