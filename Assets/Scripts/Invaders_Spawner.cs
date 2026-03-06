using UnityEngine;

public class Invaders_Spawner : MonoBehaviour
{
    public GameObject enemy1_Prefab; // Reference to Enemy1 Prefab
    public GameObject enemy2_Prefab; // Reference to Enemy2 Prefab
    public GameObject enemy3_Prefab; // Reference to Enemy3 Prefab
    
    float leftDir = -9f; // xPos for spawning enemy
    
    public float count = 0; // Used for enemy count
    
    void Start()
    {
        SpawnRow(enemy1_Prefab, 5f); // Spawning a row Enemy1
        Debug.Log("Enemy1 row has appeared!"); // Message to console
        
        SpawnRow(enemy2_Prefab, 4f); // Spawning a row Enemy2
        Debug.Log("Enemy2 row has appeared!"); // Message to console
        
        SpawnRow(enemy3_Prefab, 3f); // Spawning a row Enemy3
        Debug.Log("Enemy3 row has appeared!"); // Message to console
    }
    
    void SpawnRow(GameObject prefab, float y)
    {
        int enemyCount = 20; // Amount of enemies per row
        float spacing = 1f; // Space between enemies
        
        for(int i = 0; i < enemyCount; i++)
        {
            float x = leftDir + i * spacing; // xPos fr enemy

            Vector3 position = new Vector3(x, y, 0f); // Spawn position of enemy

            Instantiate(prefab, position, Quaternion.identity); // Spawning the enemy
            
            count++; // Per spawn of enemy, count increases
        }
    }
}