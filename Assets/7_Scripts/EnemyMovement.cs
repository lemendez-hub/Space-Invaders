using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public static float speed = 0.5f;
    public float speedToSee = speed;
    float rightBoundary = 9f;
    float leftBoundary = -9f;
    float timer = 0f;
    bool movingRight = true;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    Animator ani;
    bool moving;

    private bool isDying = false; 

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (EnemySpawner.countDown <= 0)
        {
            if (!EnemyBullet.killedPlayer)
            {
                timer += Time.deltaTime;
                move();
                int shoot = Random.Range(0, 15);
                if (timer >= 2f)
                {
                    if (shoot == 5)
                    {
                        ani.SetTrigger("isShooting");
                        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                        Destroy(shot, 3f);
                    }
                    timer = 0f;
                }

                if (transform.position.y <= Barricade.yPos)
                {
                    SceneManager.LoadScene("Credits");
                }
            }

            if (moving) ani.SetBool("isMoving", true);
            else ani.SetBool("isMoving", false);
        }
    }

    void descend()
    {
        transform.Translate(Vector3.down * 1f);
    }

    void moveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void move()
    {
        moving = true;
        if (movingRight) moveRight();
        else moveLeft();

        if (movingRight && transform.position.x >= rightBoundary)
        {
            movingRight = false;
            descend();
        }
        if (!movingRight && transform.position.x <= leftBoundary)
        {
            movingRight = true;
            descend();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDying) return; 

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            isDying = true; 

            Destroy(collision.gameObject);

            EnemySpawner.count = Mathf.Max(0, EnemySpawner.count - 1); 

            ani.SetTrigger("isDead");
            Destroy(gameObject, 1f);
        }
    }
}