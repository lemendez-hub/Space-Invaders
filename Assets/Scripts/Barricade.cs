using UnityEngine;

public class Barrier : MonoBehaviour
{
    int maxHP = 10;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            currentHP--;
            Debug.Log(currentHP);

            Destroy(collision.gameObject);

            if (currentHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
