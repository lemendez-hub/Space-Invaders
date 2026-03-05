using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    //public AudioClip ticClip;
    //public AudioClip tacClip;

    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;

    public float speed = 0.5f;
    float rBoundary = 9f;
    float lBoundary = -9f;
    bool movingRight = true;
    public static float SpeedMultiplier = 1f;

    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    Invaders_Spawn iS;

    float timer = 0f;


    void Awake()
    {
        iS = FindFirstObjectByType<Invaders_Spawn>();
    }

    void Start()
    {

    }

    void Update()
    {
        move();

        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
        //Debug.Log("Bang!");

        // todo - destroy the bullet after 3 seconds
        Destroy(shot, 3f);
        // todo - trigger shoot animation
        GetComponent<Animator>().SetTrigger("Shot_Trigger");
        //int shoot = Random.Range(0, 100);

        //timer += Time.deltaTime;
        //if (timer >= 5f)
        //{
        //    if (shoot == 67)
        //    {
        //        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
        //        //Debug.Log("Bang!");

        //        // todo - destroy the bullet after 3 seconds
        //        Destroy(shot, 3f);
        //        // todo - trigger shoot animation
        //        GetComponent<Animator>().SetTrigger("Shot_Trigger");
        //    }
        //    timer = 0f;
        //}
    }

    void descend()
    {
        transform.Translate(Vector3.down * 1f);
    }

    void moveLeft()
    {
        transform.Translate(Vector3.left * speed * SpeedMultiplier * Time.deltaTime);
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * speed * SpeedMultiplier * Time.deltaTime);
    }

    void move()
    {
        if (movingRight)
        {
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            moveRight();
        }
        else
        {
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
            moveLeft();
        }

        if (movingRight && transform.position.x >= rBoundary)
        {
            movingRight = false;
            descend();
        }
        if (!movingRight && transform.position.x <= lBoundary)
        {
            movingRight = true;
            descend();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");

        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            iS.count--;
            
            
            
            OnEnemyDied?.Invoke(10);





        }
        // todo - trigger death animation
    }

    //public void PlayTicSound()
    //{
    //    GetComponent<AudioSource>().PlayOneShot(ticClip);
    //}

    //public void PlayTacSound()
    //{
    //    GetComponent<AudioSource>().PlayOneShot(tacClip);
    //}
}
