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
    void Update()
    {
        if(C_Spawner.spawn == true)
        {
            if (C_Spawner.count <= 45)
            {
                D_SpawnerMovement.speed = 1f;
            }
            if (C_Spawner.count <= 30)
            {
                D_SpawnerMovement.speed = 2f;
            }
            if (C_Spawner.count <= 15)
            {
                D_SpawnerMovement.speed = 4f;
            }
            if (C_Spawner.count == 0)
            {
                D_SpawnerMovement.speed = 0.5f;
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