// Done for now
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class G_PLayerBullet : MonoBehaviour
{
    float speed = 5;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy1"))
        {
            K_ScoreManager.instance.AddScore(30);
        }
        if(collision.gameObject.CompareTag("Enemy2"))
        {
            K_ScoreManager.instance.AddScore(20);
        }
        if(collision.gameObject.CompareTag("Enemy3"))
        {
            K_ScoreManager.instance.AddScore(10);
        }
        if(collision.gameObject.CompareTag("EnemyS"))
        {
            K_ScoreManager.instance.AddScore(Random.Range(10, 300));
        }
    }
}