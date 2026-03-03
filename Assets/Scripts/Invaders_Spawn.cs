using UnityEngine;

public class Invaders_Spawn : MonoBehaviour
{
    public GameObject enemyS_Prefab;
    public GameObject enemy1_Prefab;
    public GameObject enemy2_Prefab;
    public GameObject enemy3_Prefab;

    float timer = 0f;

    float leftDis = -13f;
    float rightDis = 13f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer += Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        Transform eS_Instance = Instantiate(enemyS_Prefab).transform;
        Transform e1_Instance = Instantiate(enemy1_Prefab).transform;
        Transform e2_Instance = Instantiate(enemy2_Prefab).transform;
        Transform e3_Instance = Instantiate(enemy3_Prefab).transform;
    }
}
