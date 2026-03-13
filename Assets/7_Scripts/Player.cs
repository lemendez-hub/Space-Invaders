using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static float speed = 5f; // Player speed

    float lB = -10f; // Left Boundary
    float rB = 10f; // Right Boundary
    
    public GameObject bulletPrefab; // Bullet Prefab
    
    public Transform shootOffsetTransform; // Spawn position of bullet
    
    private Rigidbody2D rb; // Rigidbody
    
    Animator ani; // Animator
    
    public AudioClip shooting; // For shooting sound
    public AudioClip death; // For death sound

    void Start()
    {
        speed = 5f; // After dying, speed is set back to normal
        rb = GetComponent<Rigidbody2D>(); // Getting an Rigidbody component
        ani = GetComponent<Animator>(); // Getting an Animator component
    }

    void Update()
    {
        float movementX = 0f; // Current movment, still

        if(EnemySpawner.countDown <= 0f)
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                if(transform.position.x > lB)
                {
                    movementX -= 1f;

                    ani.SetBool("isMoving", true); // Updating animation, not idle
                }
            }

            if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                if (transform.position.x < rB)
                {
                    movementX += 1f;

                    ani.SetBool("isMoving", true); // Updating animation, not idle
                }
            }

            if(movementX == 0f)
            {
                ani.SetBool("isMoving", false); // Updaitng animation, idle
            }

            rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f);

            if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Spawning bullet

                Destroy(shot, 3f); // Destroy bullet after 3 seconds if it hits nothing

                ani.SetTrigger("isShooting"); // Updating shooting animation

                GetComponent<AudioSource>().PlayOneShot(shooting); // Play shooting sound
            }
        }
        else
        {
            rb.linearVelocity = Vector3.zero; // Unable to move
            ani.SetBool("isMoving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            speed = 0f; // Dead, no speed/movment

            ani.SetTrigger("isDead"); // Dead animation

            GetComponent<AudioSource>().PlayOneShot(death); // Death sound
        }
    }
}