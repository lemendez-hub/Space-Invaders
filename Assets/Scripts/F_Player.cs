// Done for now
using UnityEngine;
using UnityEngine.InputSystem;
public class F_Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    private Rigidbody2D rb;
    Animator ani;
    void Start()
    {
        //ani.SetBool("isAlive", true);
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        float movementX = 0f;
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movementX = movementX - 1f;
            ani.SetBool("isMoving", true);
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movementX = movementX + 1f;
            ani.SetBool("isMoving", true);
        }
        if(movementX == 0f)
        {
            ani.SetBool("isMoving", false);
        }        
        rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f);
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Destroy(shot, 3f);
            ani.SetTrigger("isShooting");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Debug.Log("Got hit");
            ani.SetTrigger("isDead");
        }
    }
}