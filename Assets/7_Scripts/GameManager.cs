using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Score text to display

    EnemySpawner spawner; // To get access to some EnemySpawner variables

    float winTimer; // Timer to change scenes
    float loseTimer; // Timer to change scenes

    string [] enemyTags = {"Enemy1", "Enemy2", "Enemy3", "SpecialEnemy"}; // An array for my enemy tags

    void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>(); // Getting access to EnemySpawner from this class
        winTimer = 6f; // Reset winTimer
        loseTimer = 6f; // Reset loseTimer
        EnemyBullet.killedPlayer = false; // Player LIVES
    }
    
    void Update()
    {
        if (EnemySpawner.spawn != true) // So enemies won't move before countdown finishes
        {
            return;
        }

        if (EnemyBullet.killedPlayer)
        {
            Lose();
            return; // Stopping Update from running
        }

        Speed();

        if(EnemySpawner.count == 0)
        {
            Win();
        }
    }

    void Speed()
    {
        // Increasing enemy speed based on enemies remaining
        if(EnemySpawner.count <= 45)
        {
            EnemyMovement.speed = 2f;
        }

        if (EnemySpawner.count <= 30)
        {
            EnemyMovement.speed = 4f;
        }

        if (EnemySpawner.count <= 15)
        {
            EnemyMovement.speed = 8f;
        }
    }
    
    void Win()
    {
        spawner.gameOver.enabled = true; // Game Over text appears

        winTimer -= Time.deltaTime; // Countdown towards 0 for Win Scene

        if(winTimer <= 0f)
        {
            SceneManager.LoadScene("Credits_Win"); // WINNER

            EnemyMovement.speed = 0.5f; // Reset enemy speed
        }
    }
    
    void Lose()
    {
        spawner.gameOver.enabled = true; // Game Over text appears

        loseTimer -= Time.deltaTime; // Countdown towards 0 for Lose Scene

        EnemyMovement.speed = 0f; // Freezing all enemies

        if(loseTimer <= 0f)
        {
            DestroyEnemies(); // Getting rid of alive enemies
            
            EnemySpawner.count = 0; // Setting enemyCount to 0 so enemyCount UI won't lie about the enemies alive

            SceneManager.LoadScene("Credits_Lose"); // LOSER

            EnemyMovement.speed = 0.5f; // Reset enemy speed
        }
    }
    
    void DestroyEnemies()
    {
        foreach(string enemy in enemyTags) // Looping through each tag/string in the enemyTag array
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy); // Retrieving all GameObjects in the scene that have this tag
        
            foreach (GameObject e in enemies) // Looping through each GameObject found with the current tag
            {
                Destroy(e); // Destroying alive/remaining enemies
            }
        }
    }
}