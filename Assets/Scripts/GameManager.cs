using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI highScoreText;

    int score = 0;
    //int highScore = 0;


    Invaders_Spawn anti;
    Enemy es;

    bool did18;
    bool did12;
    bool did6;

    void Awake()
    {
        anti = FindFirstObjectByType<Invaders_Spawn>();
        es = FindFirstObjectByType<Enemy>();
    }



    void Start()
    {

        //scoreText.text = "Score: " + score.ToString("D4");

        // todo - sign up for notification about enemy death 
        Enemy.OnEnemyDied += OnEnemyDied;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString("D4");

        if (!did18 && anti.count <= 18) { Enemy.SpeedMultiplier = 3f; did18 = true; }
        if (!did12 && anti.count <= 12) { Enemy.SpeedMultiplier = 6f; did12 = true; }
        if (!did6 && anti.count <= 6) { Enemy.SpeedMultiplier = 9f; did6 = true; }
    }




    //highScoreText.text = "HI-SCORE: " + highScore.ToString("D4");

    //if(score > highScore)
    //{
    //    highScore = score;
    //}


    void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;
    }

    void OnEnemyDied(float score)
    {
        Debug.Log($"Killed enemy worth {score}");
    }

    public void addScore(int points)
    {
        score += points;
    }
}
