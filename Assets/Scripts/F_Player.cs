// Done for now
using UnityEngine;
using UnityEngine.InputSystem;
public class F_Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movementX = 0f;
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movementX = movementX - 1f;
        }
        if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        { 
            movementX = movementX + 1f;
        }
        rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f);
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Destroy(shot, 3f);
            // todo - trigger shoot animation
            //GetComponent<Animator>().SetTrigger("Shot_Trigger");
        }
    }
}