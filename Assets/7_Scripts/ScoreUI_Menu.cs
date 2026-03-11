// Done for now
using TMPro;
using UnityEngine;
public class ScoreUI_Menu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE:" + ScoreManager.instance.score.ToString("D4");
        }
        if (highScoreText != null)
        {
            highScoreText.text = "HI-SCORE:" + ScoreManager.instance.highScore.ToString("D4");
        }
    }
}