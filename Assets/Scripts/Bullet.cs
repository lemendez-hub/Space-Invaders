using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Ensures GameObject has a RB2D component, adds one if it does not have one

public class Bullet : MonoBehaviour
{
    float speed = 5; // Speed of bullet
    
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed; // Sets upward velocity to speed units p/s
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1")) // Seeing if bullet collides with 'Enemy1'
        {
            ScoreManager.instance.AddScore(30); // 30 gets added to score
        }
        if (collision.gameObject.CompareTag("Enemy2")) // Seeing if bullet collides with 'Enemy2'
        {
            ScoreManager.instance.AddScore(20); // 20 gets added to score
        }
        if (collision.gameObject.CompareTag("Enemy3")) // Seeing if bullet collides with 'Enemy3'
        {
            ScoreManager.instance.AddScore(10); // 10 gets added to score
        }
        if (collision.gameObject.CompareTag("EnemyS")) // Seeing if bullet collides with 'EnemyS'
        {
            ScoreManager.instance.AddScore(Random.Range(10, 300)); // Number between 10 and 300 gets added to score
        }
    }
}