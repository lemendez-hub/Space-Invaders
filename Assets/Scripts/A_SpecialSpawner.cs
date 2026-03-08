// Done for now
using UnityEngine;
public class A_SpecialSpawner : MonoBehaviour
{
    public GameObject specialPrefab;
    float spawnTimer = 0f;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= 10f)
        {
            SpawnSpecial();
            spawnTimer = 0f;
        }
    }
    void SpawnSpecial()
    {
        Vector3 position = new Vector3(transform.position.x, 6f, 0f);
        GameObject special = Instantiate(specialPrefab, position, Quaternion.identity);
        C_Spawner.count++;
    }
}