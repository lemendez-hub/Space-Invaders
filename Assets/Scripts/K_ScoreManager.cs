// Done for now
using UnityEngine;
public class K_ScoreManager : MonoBehaviour
{
    public static K_ScoreManager instance;
    public int score = 0;
    public int highScore = 0;
    const string HIGH_SCORE_KEY = "HighScore";
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