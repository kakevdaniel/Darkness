using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 50;

    private Vector2 dir;


    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        DestroyBullet();
    }

    void DestroyBullet()    
    {
        Destroy(gameObject, 3);
        /* Debug.Log("Destroyed"); */
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        
    }
}
