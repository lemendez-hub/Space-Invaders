// Done for now
using UnityEngine;
public class Barricade : MonoBehaviour
{
    public static float yPos;
    int maxHP = 5;
    int currentHP;
    int bulletLayer;
    int enemyBulletLayer;
    bool isDead = false;
    Animator animator;
    void Awake()
    {
        currentHP = maxHP;
        bulletLayer = LayerMask.NameToLayer("Bullet");
        enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet");
        animator = GetComponent<Animator>();
        yPos = transform.position.y;
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
        animator.SetTrigger("isDamaged");
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