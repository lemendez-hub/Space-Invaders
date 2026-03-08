// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class D_SpawnerMovement : MonoBehaviour
{
    //public delegate void EnemyDiedFunc(float points);
    //public static event EnemyDiedFunc OnEnemyDied;
    public static float speed = 0.5f;
    public float speedToSee = speed;
    float rightBoundary = 9f;
    float leftBoundary = -9f;
    float timer = 0f;
    bool movingRight = true;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    void Update()
    {
        timer += Time.deltaTime;
        move();
        int shoot = Random.Range(0, 15);
        if(timer >= 2f)
        {
            if(shoot == 5)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Destroy(shot, 3f);
            }
            timer = 0f;
        }
        if(transform.position.y <= 2.5)
        {
            //SceneManager.LoadScene("Credits");
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
        if(movingRight)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
        if(movingRight && transform.position.x >= rightBoundary)
        {
            movingRight = false;
            descend();
        }
        if(!movingRight && transform.position.x <= leftBoundary)
        {
            movingRight = true;
            descend();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            C_Spawner.count--;
        }
    }
}