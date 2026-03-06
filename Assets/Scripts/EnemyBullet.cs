using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    float speed = 5f; // Speed of bullet

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed; // Sets downward velocity to speed units p/s
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Checks if bullet hit player
        {
            Destroy(collision.gameObject); // Destroy the player
            Destroy(gameObject); // Destory the bullet

            SceneManager.LoadScene("Menu"); // When player dies, go back to Menu
        }
    }
}