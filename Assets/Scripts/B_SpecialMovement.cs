// Done for now
using UnityEngine;
public class B_SpecialMovement : MonoBehaviour
{
    float rightBoundary = 11f;
    float timer = 0f;
    float speed = 1f;
    bool movingRight = true;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    void Update()
    {
        timer += Time.deltaTime;
        move();
        int shoot = Random.Range(0, 3);
        if(timer >= 1f)
        {
            if(shoot == 2)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Destroy(shot, 3f);
            }
            timer = 0f;
        }
    }
    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void move()
    {
        if(movingRight)
        {
            moveRight();
        }
        if(movingRight && transform.position.x >= rightBoundary)
        {
            Destroy(gameObject);
            C_Spawner.count--;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            C_Spawner.count--;
        }
    }
}