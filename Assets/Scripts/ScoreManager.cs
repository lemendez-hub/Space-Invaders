using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // A static reference for access

    public int score = 0; // current session game score
    public int highScore = 0; // Highest score saved accros sessions

    const string HIGH_SCORE_KEY = "HighScore"; // Used to store high scores

    void Awake()
    {
        if (instance == null) //If no instance, assign this
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destroying when switching scenes
        }
        else
        {
            Destroy(gameObject); // Destroy if an instance already exists
            return;
        }

        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0); // To load saved high scores from PlayerPref and if none exist, default is 0
    }

    public void AddScore(int points)
    {
        score += points; // Increase score by points

        if (score > highScore) // checks if a ther is a new high score
        {
            highScore = score; // high score is now score
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore); // saving new high score
            PlayerPrefs.Save(); // ensures high score is saved
        }
    }


    public void ResetScore()
    {
        score = 0; // resets current score
    }
}