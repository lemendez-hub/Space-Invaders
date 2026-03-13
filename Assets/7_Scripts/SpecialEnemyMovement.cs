using UnityEngine;

public class SpecialEnemyMovement : MonoBehaviour
{
    float rightBoundary = 11f; // Max distance able to travel before despawning
    float timer = 0f; // Shooting timer

    public static float speed = 1f; // Enemy speed

    bool movingRight = true; // If enemy is moving

    public GameObject bulletPrefab; // Bullet Prefab

    public Transform shootOffsetTransform; // Bullet spawn position

    public AudioClip shooting; // Audio for shot

    public AudioClip death; // Audio for death

    Animator ani; // Animatior

    private bool isDying = false; // If dead

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(!EnemyBullet.killedPlayer) // If player is not dead
        {
            timer += Time.deltaTime; // Timer increasing

            move(); // Moving

            int shoot = Random.Range(0, 3); // Chance to shoot

            if(timer >= 1f) // Has a chance to shoot every second
            {
                if(shoot == 2) // Chosen number
                {
                    GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Spanws bullet

                    GetComponent<AudioSource>().PlayOneShot(shooting); // Plays audio

                    Destroy(shot, 3f); // Disapears after 3 seconds if it hits nothing
                }

                timer = 0f; // Reset timer
            }
        }
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // Movement
    }

    void move()
    {
        if(movingRight)
        {
            moveRight();
        }

        if(!isDying && movingRight && transform.position.x >= rightBoundary)
        {
            // Dies after reaching boundary
            EnemySpawner.count = Mathf.Max(0, EnemySpawner.count - 1); 

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDying)
        {
            return; // To avoid multiple deaths
        }
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            isDying = true; // Now dead

            Destroy(collision.gameObject); // Bullet is destroyed

            EnemySpawner.count = Mathf.Max(0, EnemySpawner.count - 1); // Enemy count decreases

            ani.SetTrigger("isDead"); // Plays death animation

            GetComponent<AudioSource>().PlayOneShot(death); // Plays death audio

            Destroy(gameObject, 1f); // Gets destroyed
        }
    }
}