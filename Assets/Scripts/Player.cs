using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // Refernce for bullet Prefab
    public Transform shootOffsetTransform; // Reference to the shooting position
    
    public float speed = 10f; // Player speed
    
    public Rigidbody2D rb; // Reference to GameObject's Rigidbody2D component
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Retrieving and storing the RB
    }
    
    void Update()
    {
        float movementX = 0f; // xPos movement
        
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) // If 'a' or 'leftArrowKey' is pressed
        {
            movementX = movementX - 1f; // Move left on xAxis
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) // If 'd' or 'rightArrowKey' is pressed
        { 
            movementX = movementX + 1f; // Move right on xAxis
        }
        
        rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f); // Setting velocity of player
        
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) // If 'spaceKey' was pressed
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity); // Shoot bullet
            
            Destroy(shot, 3f); // Bullet gets destroyed after 3 seconds if it does not hit anything
            
            // todo - trigger shoot animation
            //GetComponent<Animator>().SetTrigger("Shot_Trigger");
        }
    }
}