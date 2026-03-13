using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Current score for session
    public int highScore = 0; // Highest score saved

    const string HIGH_SCORE_KEY = "HighScore"; // A key used to store high score

    public static ScoreManager instance; // An instance for classes to use, for scores

    void Awake()
    {
        // So only one SM will exist
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

        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0); // Load saved high score from PlayerPrefs, 0 if none found
    }

    public void AddScore(int points)
    {
        score += points; // Increase points

        if(score > highScore)
        {
            highScore = score; // If score is bigger than high score, high score now has the value of score

            // Saving new high score
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        score = 0; // Resets current session score
    }
}