using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;

    GameManager manager;
    void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
        //Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy1"))
        {
            manager.addScore(30);
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            manager.addScore(20);
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            manager.addScore(10);
        }
        if (collision.gameObject.CompareTag("EnemyS"))
        {
            manager.addScore(Random.Range(10, 300));
        }
        if(collision.gameObject.CompareTag("Barricade"))
        {
            Debug.Log("What are you doing bro?");
        }
    }
}
