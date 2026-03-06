using UnityEngine;

public class SpecialEnemy_Movement : MonoBehaviour
{
    float rBoundary = 11f; // Right limit

    float timer = 0; // Timer for enemy attack
    //float moveTimer = 0f; // Timer for enemy movemnt
    
    bool movingRight = true; // If enemy is moving to the right

    public float speed = 1f;

    public GameObject bulletPrefab; // Reference for a bullet prefab
    public Transform shootOffsetTransform; // Reference for shooting position of bullet

    Invaders_Spawner iS; // To access Invaders_Spawner

    void Awake()
    {
        iS = FindAnyObjectByType<Invaders_Spawner>(); // Instance for Invaders_Spawner
    }

    void Update()
    {
        timer += Time.deltaTime; // Attack timer increasing
        move();


        //moveTimer += Time.deltaTime; // Movement timer increasing

        //if (moveTimer >= 2f) // Every 2 seconds, enemies will move
        //{
        //    move(); // To move 1 floating point number, moves discretely
        //    moveTimer = 0f; // Reset timer to meet condition again later
        //}

        int shoot = Random.Range(0, 3); // Random number for enemy to shoot

        if (timer >= 1f) // Timer reaches 5 seconds, enemy has opportunity to shoot
        {
            if (shoot == 2) // If enemy guesses number, enemy shoots
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Enemy shoots
                Destroy(shot, 3f); // Destroy enemy bullet after 3 seconds, similar to player
            }
            timer = 0f; // Reset timer to meet condition again later
        }
    }
    
    void moveRight()
    {
        //transform.Translate(Vector3.right * 1f); // Enemy goes right by 1 unit
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //Debug.Log("Special Enemy Moving Right!"); // Message to console
    }

    void move()
    {
        if(movingRight) // If true
        {
            moveRight(); // Move right
        }
        if (movingRight && transform.position.x >= rBoundary) // If true and max right distance is reached
        {
            Destroy(gameObject); // Destroy/Disappear Special Enemy
            iS.count--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) // If enemy gets hit by a "Bullet"
        {
            Destroy(collision.gameObject); // Bullet is destroyed
            Destroy(gameObject); // Destoy enemy
            Debug.Log("Oh No Bro!"); // Message to console

            iS.count--; // Decrease enemy count in Invaders_Spawn class
        }
    }
}