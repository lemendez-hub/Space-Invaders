using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;

    GameManager manager;

    Barrier bs;

    void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
        bs = FindAnyObjectByType<Barrier>();
    }



    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        //Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Barricade"))
        {
            bs.currentHP--;
            Debug.Log("Destroy it!");
        }
    }
}
