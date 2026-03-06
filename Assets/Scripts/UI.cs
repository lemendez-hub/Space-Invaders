using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to dislay score
    public TextMeshProUGUI highScoreText;  // Reference to display high score

    void Update()
    {
        if (ScoreManager.instance == null) // If there is no instance of ScoreManager, return to avoid error
        {
            return; // return
        }

        if (scoreText != null) // Update current scor display
        {
            scoreText.text = "Score: " + ScoreManager.instance.score.ToString("D4"); // Updating score with leading zeros
        }
        
        if (highScoreText != null) // If not null, update high score display
        {
            highScoreText.text = "High Score: " + ScoreManager.instance.highScore.ToString("D4"); // Updating score with leading zeros
        }
    }
}
