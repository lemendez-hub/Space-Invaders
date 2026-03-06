using UnityEngine;

public class Barricade : MonoBehaviour
{
    int maxHP = 10; // Max HP for barricade
    
    public int currentHP; // Current HP
    
    bool isDead = false; // Tracks if barricade has been destroyed

    // For performance, avoids repeated string lookups
    int bulletLayer;
    int enemyBulletLayer;
    
    void Awake()
    {
        currentHP = maxHP; // Current HP is the same as Max HP
        
        bulletLayer = LayerMask.NameToLayer("Bullet"); // Just to avoid calling NameToLayer a lot
        enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet"); // Same as above
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead) // If barricade is destroyed, ignore future collisions
        {
            return; // Returns
        }
        
        int otherLayer = collision.gameObject.layer; // Get layer of colliding object
        
        if(otherLayer == bulletLayer || otherLayer == enemyBulletLayer) // Checks if the collision is with 'player' or 'enemy' bullet
        {
            Destroy(collision.gameObject); // Destroys teh bullet
            TakeDamage(1); // Damage to barricade
        }
    }
    
    void TakeDamage(int amount)
    {
        // Same as the one in OnCollisionEnter2D
        if(isDead)
        {
            return;
        }
        
        currentHP -= amount; // Subtracting HP by 1
        
        if(currentHP < 0) // HP needs to be minimum of 0
        {
            currentHP = 0; // Setting HP to 0
        }
        
        Debug.Log($"Barricade HP: {currentHP}"); // Printing barriade HP to console
        
        if(currentHP == 0) // If depleted, barricade is gone
        {
            isDead = true; // Setting it to destroyed
            Destroy(gameObject); // Destroying the barricade
        }
    }
}