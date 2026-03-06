using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public delegate void EnemyDiedFunc(float points);
    //public static event EnemyDiedFunc OnEnemyDied;
    
    public static float speed = 0.5f; // Speed of enemy
    public float speedToSee = speed; // This is just to see speed in inspector, has no use
    
    float rBoundary = 9f; // Max right distance for an enemy
    float lBoundary = -9f; // Max left distance for an enemy
    
    bool movingRight = true; // If enemy is moving right
    
    float timer = 0f; // Timer used for enemy attack time
    
    //float moveTimer = 0; // Timer used for enemy movemnt
    
    public GameObject bulletPrefab; // Reference for a bullet prefab
    public Transform shootOffsetTransform; // Reference for shooting position of bullet
    
    Invaders_Spawner iS; // To get access to Invaders_Spawn class
    
    void Awake()
    {
        iS = FindFirstObjectByType<Invaders_Spawner>(); // Instance for Invaders_Spawn
    }
    
    void Update()
    {
        timer += Time.deltaTime; // Shooting timer increasing
        
        move();
        
        //moveTimer += Time.deltaTime; // Movement timer increasing
        
        //if(moveTimer >= stepInterval) // Every 2 seconds, enemies will move
        //{
        //    move(); // To move 1 floating point number, moves discretely
        //    moveTimer = 0f; // Reset timer to meet condition again later
        //}
        
        int shoot = Random.Range(0, 25); // Random number for enemy to shoot
        
        if(timer >= 2f) // Timer reaches 5 seconds, enemy has opportunity to shoot
        {
            if(shoot == 5) // If enemy guesses number, enemy shoots
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Enemy shoots
                Destroy(shot, 3f); // Destroy enemy bullet after 3 seconds, similar to player
            }
            timer = 0f; // Reset timer to meet condition again later
        }
    }
    
    void descend()
    {
        transform.Translate(Vector3.down * 1f); // Enemy goes downward by 1 unit
        //Debug.Log("Enemy Descending!"); // Message to console
    }
    
    void moveLeft()
    {
        //transform.Translate(Vector3.left * 1f); // Enemy goes left by 1 unit
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Moving Left
        //Debug.Log("Enemy Moving Left!"); // Message to console
    }
    
    void moveRight()
    {
        //transform.Translate(Vector3.right * 1f); // Enemy goes right by 1 unit
        transform.Translate(Vector3.right * speed * Time.deltaTime); // Moving Right
        //Debug.Log("Enemy Moving Right!"); // Message to console
    }
    
    void move()
    {
        if(movingRight) // If true
        {
            moveRight(); // Move right
        }
        else // If false
        {
            moveLeft(); // Move left
        }
        if(movingRight && transform.position.x >= rBoundary) // If true and max right distance is reached
        {
            movingRight = false; // Time to move left
            descend(); // Move downward
        }
        if(!movingRight && transform.position.x <= lBoundary) // If false/moving left and max left distance is reached
        {
            movingRight = true; // Time to move right
            descend(); // Move downward
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) // If enemy gets hit by a "Bullet"
        {
            Destroy(collision.gameObject); // Bullet is destroyed
            Destroy(gameObject); // Destoy enemy

            iS.count--; // Decrease enemy count in Invaders_Spawn class
        } 
    }
}