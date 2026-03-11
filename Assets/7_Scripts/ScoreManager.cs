// Done for now
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    const string HIGH_SCORE_KEY = "HighScore";
    public static ScoreManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }
    public void AddScore(int points)
    {
        score += points;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }
    }
    public void ResetScore()
    {
        score = 0;
    }
}