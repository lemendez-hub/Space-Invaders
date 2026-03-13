using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Gives GO a RB2D if it does not have one, as it is required for this class

public class PLayerBullet : MonoBehaviour
{
    float speed = 5; // Bullet speed

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed; // Setting the way the bullet will go
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Player gets certain points after hitting certain enemies
        if(collision.gameObject.CompareTag("Enemy1"))
        {
            ScoreManager.instance.AddScore(30);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy2"))
        {
            ScoreManager.instance.AddScore(20);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy3"))
        {
            ScoreManager.instance.AddScore(10);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("SpecialEnemy"))
        {
            ScoreManager.instance.AddScore(Random.Range(10, 300));
            Destroy(gameObject);
        }
    }
}