// Done for now
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class J_GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //void Start()
    //{
    //    // todo - sign up for notification about enemy death
    //    //Enemy.OnEnemyDied += OnEnemyDied;
    //}
    EnemySpawner spawner;
    void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Update()
    {
        if(EnemySpawner.spawn == true)
        {
            if (EnemySpawner.count <= 45)
            {
                EnemyMovement.speed = 1f;
            }
            if (EnemySpawner.count <= 30)
            {
                EnemyMovement.speed = 2f;
            }
            if (EnemySpawner.count <= 15)
            {
                EnemyMovement.speed = 4f;
            }
            if (EnemySpawner.count == 0)
            {
                spawner.gameOver.enabled = true;
                EnemyMovement.speed = 0.5f;
                //SceneManager.LoadScene("Credits");
            }
        }
    }
    //void OnDestroy()
    //{
    //    Enemy.OnEnemyDied -= OnEnemyDied;
    //}
    //void OnEnemyDied(float score)
    //{
    //    Debug.Log($"Killed enemy worth {score}");
    //}
}