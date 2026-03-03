using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    public float speed = 10f;

    public Rigidbody2D rb;

    void Start()
    {
        // todo - get and cache animator
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float movementX = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            movementX = movementX - 1f;
        }
        if(Keyboard.current.dKey.isPressed)
        {
            movementX = movementX + 1f;
        }
        rb.linearVelocity = new Vector3(movementX * speed, 0f, 0f);
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");

            // todo - destroy the bullet after 3 seconds
            Destroy(shot, 3f);
            // todo - trigger shoot animation
            GetComponent<Animator>().SetTrigger("Shot_Trigger");
        }
    }
}
