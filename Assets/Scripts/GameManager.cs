using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Score Text to update


    Invaders_Spawner iS; // To access Invaders_Spawn class

    void Awake()
    {
        iS = FindFirstObjectByType<Invaders_Spawner>(); // Instance for Invaders_Spawn
    }

    //void Start()
    //{
    //    // todo - sign up for notification about enemy death
    //    //Enemy.OnEnemyDied += OnEnemyDied;
    //}

    void Update()
    {
        if(iS.count <= 45) // If total enemy count is less than or equal to 45, speed increases once
        {
            Enemy.speed = 1f; // Set speed to 1
        }
        if(iS.count <= 30) // If total enemy count is less than or equal to 30, speed increases once
        {
            Enemy.speed = 2f; // Set speed to 4
        }
        if(iS.count <= 15) // If total enemy count is less than or equal to 15, speed increases once
        {
            Enemy.speed = 4f; // Set speed to 8;
        }
        if (iS.count == 0)
        {
            Enemy.speed = 0.5f;
            SceneManager.LoadScene("Credits"); // When enemy count is 0, go back to Menu
        }
    }
    
    //void OnDestroy()
    //{
    //    Enemy.OnEnemyDied -= OnEnemyDied;
    //}
    
    //void OnEnemyDied(float score)
    //{
    //    Debug.Log($"Killed enemy worth {score}");
    //}
}