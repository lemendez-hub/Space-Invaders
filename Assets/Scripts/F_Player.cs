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
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        float movementX = 0f;
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movementX = movementX - 1f;
            ani.SetBool("movingNow", true);
        }
        else if(movementX == 0f)
        {
            ani.SetBool("movingNow", false);
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movementX = movementX + 1f;
            ani.SetBool("movingNow", true);
        }
        else if(movementX == 0f)
        {
            ani.SetBool("movingNow", false);
        }        
        rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f);
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Destroy(shot, 3f);
            ani.SetTrigger("isShooting");
        }
    }
}