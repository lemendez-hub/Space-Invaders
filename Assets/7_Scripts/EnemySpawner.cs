// Done for now
using TMPro;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public TextMeshProUGUI one;
    public TextMeshProUGUI two;
    public TextMeshProUGUI three;
    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI gameOver;
    float leftBoundary = -9f;
    public static float countDown = 4f;
    public static int count = 0;
    public int enemyCountInt;
    public static bool spawn = false;
    void Start()
    {
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        gameOver.enabled = false;
    }
    void Update()
    {
        enemyCountInt = count;
        enemyCount.text = $"EnemyCount:{enemyCountInt}";
        countDown -= Time.deltaTime;
        if (countDown <= 3f && countDown > 2f)
        {
            three.enabled = true;
            if(!spawn)
            {
                spawn = true;
                SpawnRow(enemy1Prefab, 5f);
                SpawnRow(enemy2Prefab, 4f);
                SpawnRow(enemy3Prefab, 3f);
            }
        }
        if (countDown <= 2f && countDown > 1f)
        {
            three.enabled = false;
            two.enabled = true;
        }
        if (countDown <= 1f && countDown > 0f)
        {
            two.enabled = false;
            one.enabled = true;
        }
        if (countDown <= 0f)
        {
            one.enabled = false;
        }
    }
    void SpawnRow(GameObject prefab, float y)
    {
        int enemiesPerRow = 10; 
        float spacing = 1f;

        for (int i = 0; i < enemiesPerRow; i++)
        {
            float x = leftBoundary + i * spacing;
            Vector3 position = new Vector3(x, y, 0f);
            Instantiate(prefab, position, Quaternion.identity);
            count++;
        }
    }
}