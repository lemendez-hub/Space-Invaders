// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class E_EnemyBullet : MonoBehaviour
{
    float speed = 5f;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("Credits");
        }
    }
}