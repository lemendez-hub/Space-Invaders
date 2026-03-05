using UnityEngine;

public class Barrier : MonoBehaviour
{
    int count = 0;
    int maxHP = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            count++;
            Debug.Log(count);
            Destroy(collider.gameObject);
        }
        if(count == maxHP)
        {
            Destroy(gameObject);
        } 
    }
}
