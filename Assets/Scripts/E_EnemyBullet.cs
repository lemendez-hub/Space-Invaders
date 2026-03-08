// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class E_EnemyBullet : MonoBehaviour
{
    float speed = 5f;
    Animator ani;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        ani = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
            //Animator playerAni = collision.gameObject.GetComponent<Animator>();
            //ani = collision.gameObject.GetComponent<Animator>();
            //playerAni.SetTrigger("isDead");

            Destroy(gameObject);
            //SceneManager.LoadScene("Credits");
        }
    }
}