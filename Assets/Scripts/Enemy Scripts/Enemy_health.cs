using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    [SerializeField]
    private int zhealth;
    
    void Update()
    {
        if(zhealth < 1){
            Destroy(gameObject);
            Score.scoreValue += 20;
        } 
    }

    void OnTriggerEnter2D(Collider2D target) 
    {   
        if (target.CompareTag("bullet"))
        {
            Score.scoreValue += 10;
            zhealth -= GameObject.Find("Player").GetComponent<player>().currWeapon.damage;
            Destroy(target.gameObject);
        }
        
    }
    
}
