using UnityEngine;

public class SpecialEnemyMovement : MonoBehaviour
{
    float rightBoundary = 11f;
    float timer = 0f;
    public static float speed = 1f;
    bool movingRight = true;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    Animator ani;

    private bool isDying = false;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (!EnemyBullet.killedPlayer)
        {
            timer += Time.deltaTime;
            move();
            int shoot = Random.Range(0, 3);
            if (timer >= 1f)
            {
                if (shoot == 2)
                {
                    GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                    Destroy(shot, 3f);
                }
                timer = 0f;
            }
        }
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void move()
    {
        if (movingRight)
        {
            moveRight();
        }

        if (!isDying && movingRight && transform.position.x >= rightBoundary)
        {
            EnemySpawner.count = Mathf.Max(0, EnemySpawner.count - 1);
            Destroy(gameObject);
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