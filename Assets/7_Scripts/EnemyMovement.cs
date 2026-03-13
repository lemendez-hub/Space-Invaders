using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public static float speed = 0.5f; // Speed of enemy

    public float speedToSee = speed; // Ignore, this is just to see speed in inspector

    float rightBoundary = 10f; // Max xPositive distance
    float leftBoundary = -10f; // Max xNegative distance
    float stepDownAmount = 0.2f; // YPos downward
    float timer = 0f; // Shooting timer
    
    // This is shared accross all enemies
    static int dir = 1; // Current direction; 1 = right, -1 = left
    static int stepDownFrame = -1; // The exact frame where enemies go downward
    static int lastStepDownFrame = -1; // Prevents direction from flipping multiple times in same frame

    bool moving; // If enemy is moving, and for animation
    bool isDying = false; // If enemy died
    
    public GameObject bulletPrefab; // Bullet prefab
    public Transform shootOffsetTransform; // Bullet spawn pos
    
    public AudioClip shooting; // Shooting sound
    public AudioClip death; // Death sound
    
    Animator ani; // Animator
    
    void Awake()
    {
        ani = GetComponent<Animator>(); // Animator
    }
    
    void Update()
    {
        if(EnemySpawner.countDown > 0) // If countdown is active, do not do anything, stop movement
        {
            return;
        }
    
        if(EnemyBullet.killedPlayer) // If player is dead, stop everything
        {
            return;
        }
        
        timer += Time.deltaTime; // Shooting timer increasing
        
        Move(); // Enemy movement
        
        int shoot = Random.Range(0, 15); // Random chance to shoot
        
        if(timer >= 2f) // Shooting every two seconds
        {
            if(shoot == 5) // If 5, shoot, small chance
            {
                ani.SetTrigger("isShooting"); // Shooting animation
        
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Spawning bullet
                
                GetComponent<AudioSource>().PlayOneShot(shooting); // Bullet sound
                
                Destroy(shot, 3f); // Destroy bullet after 3 seconds
            }
            
            timer = 0f; // Reset shooitng timer
        }
        
        if(transform.position.y <= Barricade.yPos) // If enemy reaches barricade position, lose
        {
            SceneManager.LoadScene("Credits_Lose"); // Go to Credits_Lose
        }
        
        ani.SetBool("isMoving", moving); // Update movement animation
    }
    
    void Move()
    {
        moving = true; // Moving
    
        if(Time.frameCount == stepDownFrame) // If this is the scheduled frame for moving down, all will do
        {
            if(lastStepDownFrame != stepDownFrame) // Reverse only once per step-down
            {
                dir *= -1; // Reverse direction
                lastStepDownFrame = stepDownFrame;
            }
        
            transform.Translate(Vector3.down * stepDownAmount); // Enemy moving downward
            
            return; // Skiping horizontal movement
        }
        
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime); // Regular movement
        
        if(dir == 1 && transform.position.x >= rightBoundary) // If going right and position exceeded boundry
        {
            stepDownFrame = Time.frameCount + 1; // Trigger downward movement next frame
        }
        else if(dir == -1 && transform.position.x <= leftBoundary) // If going left and position exceeded boundry
        {
            stepDownFrame = Time.frameCount + 1; // Trigger downward movement next frame
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDying) // Prevents multiple deaths
        {
            return;
        }
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) // If hit by player bullet
        {
            isDying = true; // Now dead

            Debug.Log("Enemy Dead!"); // Message to console
        
            Destroy(collision.gameObject); // Destory player bullet
            
            EnemySpawner.count = Mathf.Max(0, EnemySpawner.count - 1); // Decrease enemy count
            
            ani.SetTrigger("isDead"); // Death animation
            
            GetComponent<AudioSource>().PlayOneShot(death); // Death sound
            
            Destroy(gameObject, 1f); // Destory after animation
        }
    }
}