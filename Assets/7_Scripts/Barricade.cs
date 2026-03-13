using UnityEngine;
public class Barricade : MonoBehaviour
{
    public static float yPos; // Y-Position of GameObject/Barricade

    int maxHP = 5; // Maximum Barricade HP
    int currentHP; // Current Barricade HP
    int bulletLayer; // Player Bullet Layer
    int enemyBulletLayer; // Enemy Bullet Layer

    bool isDead = false; // If barricade is destroyed or not

    Animator animator; // Animator
    void Awake()
    {
        currentHP = maxHP; // Current HP gets set to MaxHP

        bulletLayer = LayerMask.NameToLayer("Bullet"); // Assigning PlayerBullet Layer
        enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet"); // Assigning EnemyBulletLayer

        animator = GetComponent<Animator>(); // Animator Component

        yPos = transform.position.y; // Getting the Barricades Y-Pos
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead) // Checking if barricade is destroyed
        {
            return; // Return
        }

        int otherLayer = collision.gameObject.layer; // Get layer of object that collided

        if(otherLayer == bulletLayer || otherLayer == enemyBulletLayer) // Checking if it is a bullet from player or enemy
        {
            Destroy(collision.gameObject); // Destroy bullet

            TakeDamage(1); // HP minus 1

            Debug.Log("Damage Taken!"); // Message to console
        }
    }
    void TakeDamage(int amount)
    {
        if(isDead) // Checking if barricade is destroyed
        {
            return;
        }

        animator.SetTrigger("isDamaged"); // Play animation frame per damage take

        currentHP -= amount; // HP minus 1

        if(currentHP < 0) // Barricade HP goes below 0
        {
            currentHP = 0; // HP remains at 0
        }

        Debug.Log($"Barricade HP: {currentHP}"); // Displaying Barricade HP

        if(currentHP == 0) // If destroyed
        {
            isDead = true; // Destroyed

            Destroy(gameObject); // Destroy Barricade

            Debug.Log("Barricade Destroyed"); // Message to console
        }
    }
}