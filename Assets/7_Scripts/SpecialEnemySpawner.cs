using UnityEngine;

public class SpecialEnemySpawner : MonoBehaviour
{
    public static float spawnTimer = 0f; // Timer to spawn

    public GameObject specialPrefab; // Enemy Prefab

    void Update()
    {
        spawnTimer += Time.deltaTime; // Timer increase

        if(spawnTimer >= 10f)
        {
            if(!EnemyBullet.killedPlayer || EnemySpawner.count == 0)
            {
                // Does not spawn or timer does not increase if enemies are all dead or if player died
                SpawnSpecial();

                spawnTimer = 0f;
            }
        }
    }

    void SpawnSpecial()
    {
        Vector3 position = new Vector3(transform.position.x, 6f, 0f); // Position of enemy

        GameObject special = Instantiate(specialPrefab, position, Quaternion.identity); // Spawning enmey

        EnemySpawner.count++; // Increasing enemy count per spawn
    }
}