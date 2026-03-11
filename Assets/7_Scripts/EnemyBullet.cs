// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyBullet : MonoBehaviour
{
    float speed = 5f;
    Animator ani;
    EnemySpawner spawner;
    public static bool killedPlayer = false;
    void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        ani = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            spawner.gameOver.enabled = true;
            killedPlayer = true;
            Player.speed = 0f;
            EnemyMovement.speed = 0f;
            SpecialEnemyMovement.speed = 0f;
            Destroy(gameObject);
            Destroy(collision.gameObject, 3f);
        }
    }
}