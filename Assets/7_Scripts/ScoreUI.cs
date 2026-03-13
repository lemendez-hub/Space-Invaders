using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // To display score text in Game
    public TextMeshProUGUI highScoreText; // To display high score in Game

    void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = "SCORE:" + ScoreManager.instance.score.ToString("D4"); // Displaying current session score
        }

        if(highScoreText != null)
        {
            highScoreText.text = "HI-SCORE:" + ScoreManager.instance.highScore.ToString("D4"); // Displaying overall high score
        }
    }
}