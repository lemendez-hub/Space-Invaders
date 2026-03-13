using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    float speed = 5f; // Speed of enemy bullet
    
    public static bool killedPlayer = false; // Static boolean if player is dead
    
    Animator ani; // Animator
    
    EnemySpawner spawner; // A refernce to EnemySpawner class
    
    void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>(); // Access to EnemySpawner
    }
    
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed; // Setting speed and direction of enemy bullet
        
        ani = GetComponent<Animator>(); // Animator
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) // If enemy bullet hit player
        {        
            killedPlayer = true; // Player has died

            Debug.Log("Player Dead!");
            
            Destroy(gameObject); // Enemy bullet is destroyed
            
            Destroy(collision.gameObject, 3f); // Player is destroyed
        }
        
        // If colliding with player bullet, both get destroyed
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}