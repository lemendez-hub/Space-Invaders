using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1Prefab; // Enemy1 Prefab
    public GameObject enemy2Prefab; // Enemy2 Prefab
    public GameObject enemy3Prefab; // Enemy3 Prefab

    public TextMeshProUGUI one; // Text in Unity Editor used for a countdwon
    public TextMeshProUGUI two; // Text in Unity Editor used for a countdown
    public TextMeshProUGUI three; // Text in Unity Editor used for a countdown
    public TextMeshProUGUI enemyCount; // Text that displays total enemies alive
    public TextMeshProUGUI gameOver; // Game Over Text

    float leftBoundary = -10f; // Far left side from where enemies will spawn

    public static float countDown = 4f; // Timer/Countdown for when game will start

    public static int count = 0; // Count of enemies

    public int enemyCountInt; // Ignore, this is to view enemy, used for text

    public static bool spawn = false; // If enemies have spawned, bool so it would only happen once

    void Awake()
    {
        countDown = 4f; // Reset countDown when coming into this scene agian
        spawn = false; // Same with spawn
        count = 0; // Same here

        one.enabled = false; // Text is disabled
        two.enabled = false; // Text is disabled
        three.enabled = false; // Text is disabled
        gameOver.enabled = false; // Text is disabled
    }

    void Update()
    {
        enemyCountInt = count; // Enemy count

        enemyCount.text = $"EnemyCount:{enemyCountInt}"; // Displaying enemy count

        countDown -= Time.deltaTime; // Counting down for game start

        if(countDown <= 3f && countDown > 2f) // Enables/ Disables text (3, 2, 1) then start
        {
            three.enabled = true;

            if(!spawn) // Enemies not spawned in 
            {
                spawn = true; // Enemies now spawned in

                ScoreManager.instance.ResetScore(); // Reset session score for a new one

                SpawnRow(enemy1Prefab, 5f); // Spawn row of Enemy1
                SpawnRow(enemy2Prefab, 4f); // Spawn row of Enemy2
                SpawnRow(enemy3Prefab, 3f); // Spawn row of Enemy3
            }
        }

        if(countDown <= 2f && countDown > 1f)
        {
            three.enabled = false;
            two.enabled = true;
        }

        if(countDown <= 1f && countDown > 0f)
        {
            two.enabled = false;
            one.enabled = true;
        }

        if(countDown <= 0f)
        {
            one.enabled = false;
        }
    }

    void SpawnRow(GameObject prefab, float y)
    {
        int enemiesPerRow = 20; // 20 enemies per row

        float spacing = 1f; // Space in between each enemy

        for(int i = 0; i < enemiesPerRow; i++) // Process to create enemy
        {
            float x = leftBoundary + i * spacing; // Enemy xPos

            Vector3 position = new Vector3(x, y, 0f); // Setting Enemy Position

            Instantiate(prefab, position, Quaternion.identity); // Spawning in the enemy

            count++; // Increasing enemy count per spawn
        }
    }
}