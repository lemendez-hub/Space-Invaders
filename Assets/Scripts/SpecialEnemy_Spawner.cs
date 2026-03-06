using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyS_Prefab; // Refernce for a Special Enemy Prefab
    float timer = 0f; // Timer used for spawn

    Invaders_Spawner iS; // To access Invaders_Spawner

    void Awake()
    {
        iS = FindAnyObjectByType<Invaders_Spawner>(); // Instance for Invaders_Spawner
    }

    void Update()
    {
        timer += Time.deltaTime; // Timer increases
        
        if(timer >= 15f) // When timer reaches 15
        {
            SpawnSpecial(); // Spawn Special GameObject
            timer = 0f; // Reset timer
        }
    }
    
    void SpawnSpecial()
    {
        Vector3 position = new Vector3(transform.position.x, 6f, 0f); // Set GameObject position, xPos same as G.O. in Editor, yPos is 6
        
        GameObject special = Instantiate(enemyS_Prefab, position, Quaternion.identity); // Spawning

        iS.count++; // Increase enemy count

        Debug.Log("Special Enemy Has Been Spotted!"); // Message to Console
    }
}