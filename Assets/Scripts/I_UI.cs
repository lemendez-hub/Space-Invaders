// Done for now
using TMPro;
using UnityEngine;
public class I_UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = "SCORE:" + K_ScoreManager.instance.score.ToString("D4");
        }
        if(highScoreText != null)
        {
            highScoreText.text = "HI-SCORE:" + K_ScoreManager.instance.highScore.ToString("D4");
        }
    }
}