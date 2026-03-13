using TMPro;
using UnityEngine;

public class ScoreUI_Menu : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // For displaying score in Menu
    public TextMeshProUGUI highScoreText; // For displaying high score in Menu

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE:" + ScoreManager.instance.score.ToString("D4"); // Updaitng current session score
        }

        if (highScoreText != null)
        {
            highScoreText.text = "HI-SCORE:" + ScoreManager.instance.highScore.ToString("D4"); // Updating overall high score
        }
    }
}