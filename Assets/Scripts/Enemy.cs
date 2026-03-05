using UnityEngine;

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


    Invaders_Spawn iS;


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
