using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour
{
    //public float speed;
    public Transform player;
    private Rigidbody2D rb;

    private Transform playerPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        /*if(Vector2.Distance(transform.position, playerPos.position) > 0.3f);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);*/
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    


}
