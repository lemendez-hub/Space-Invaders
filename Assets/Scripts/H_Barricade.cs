// Done for now
using UnityEngine;
public class H_Barricade : MonoBehaviour
{
    int maxHP = 10;
    int currentHP;
    bool isDead = false;
    int bulletLayer;
    int enemyBulletLayer;
    void Awake()
    {
        currentHP = maxHP;
        bulletLayer = LayerMask.NameToLayer("Bullet");
        enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead)
        {
            return;
        }
        int otherLayer = collision.gameObject.layer;
        if(otherLayer == bulletLayer || otherLayer == enemyBulletLayer)
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
    void TakeDamage(int amount)
    {
        if(isDead)
        {
            return;
        }
        currentHP -= amount;
        if(currentHP < 0)
        {
            currentHP = 0;
        }
        Debug.Log($"Barricade HP: {currentHP}");
        if(currentHP == 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}