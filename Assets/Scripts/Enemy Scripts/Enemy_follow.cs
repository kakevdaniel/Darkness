using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour
{
    public float speed;
    

    private Transform playerPos;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 0.3f);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    
}
