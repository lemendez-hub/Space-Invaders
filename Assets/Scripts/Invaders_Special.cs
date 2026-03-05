using UnityEngine;

public class Invaders_Special : MonoBehaviour
{
    //public GameObject enemyS_Prefab;
    float leftDir = -9f;
    float rightDir = 9f;
    float timer = 0f;
    //float enemyCount;
    //public float count = 0;

    bool movingRight = true;
    float speed = 0.5f;

    void Update()
    {
        move();
    }


    void moveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
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

        if (movingRight && transform.position.x >= 10)
        {
            movingRight = false;
        }
        if (!movingRight && transform.position.x <= -10)
        {
            movingRight = true;
        }
    }
}
