using UnityEngine;
public class Invaders_Spawn : MonoBehaviour
{
    public GameObject enemy1_Prefab;
    public GameObject enemy2_Prefab;
    public GameObject enemy3_Prefab;
    float leftDir = -9f;
    //float rightDir = 9f;
    //float timer = 0f;
    //float enemyCount;
    public float count = 0;

    //public GameObject enemyS_Prefab;
    float timer = 0f;
    bool movingRight = true;
    float speed = 0.5f;

    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= 15f)
    //    {
    //        SpawnSpecial();
    //        timer = 0f;
    //    }
    //}


    //void SpawnSpecial()
    //{
    //    Vector3 position = new Vector3(transform.position.x, 6f, 0f);
    //    GameObject special = Instantiate(enemyS_Prefab, position, Quaternion.identity);
    //    Debug.Log("Special enemy has been spotted!");
    //    Destroy(special, 10f);
    //}

    void Start()
    {
        SpawnRow(enemy1_Prefab, 5f);
        Debug.Log("Enemy1 row has appeared!");
        SpawnRow(enemy2_Prefab, 4f);
        Debug.Log("Enemy2 row has appeared!");
        SpawnRow(enemy3_Prefab, 3f);
        Debug.Log("Enemy3 row has appeared!");
    }
    void SpawnRow(GameObject prefab, float y)
    {
        int enemyCount = 10;
        float spacing = 1f;

        for (int i = 0; i < enemyCount; i++)
        {
            float x = leftDir + i * spacing;
            Vector3 position = new Vector3(x, y, 0f);

            Instantiate(prefab, position, Quaternion.identity);
            count++;
        }
    }
}