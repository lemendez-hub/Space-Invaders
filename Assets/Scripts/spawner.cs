using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyS_Prefab;
    float timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 15f)
        {
            SpawnSpecial();
            timer = 0f;
        }
    }
    void SpawnSpecial()
    {
        Vector3 position = new Vector3(transform.position.x, 6f, 0f);
        GameObject special = Instantiate(enemyS_Prefab, position, Quaternion.identity);
        Debug.Log("Special enemy has been spotted!");
        Destroy(special, 10f);
    }
}
