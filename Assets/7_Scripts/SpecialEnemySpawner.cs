// Done for now
using UnityEngine;
public class SpecialEnemySpawner : MonoBehaviour
{
    float spawnTimer = 0f;
    public GameObject specialPrefab;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= 10f)
        {
            if(!EnemyBullet.killedPlayer)
            {
                SpawnSpecial();
            }
            spawnTimer = 0f;
        }
    }
    void SpawnSpecial()
    {
        Vector3 position = new Vector3(transform.position.x, 6f, 0f);
        GameObject special = Instantiate(specialPrefab, position, Quaternion.identity);
        EnemySpawner.count++;
    }
}