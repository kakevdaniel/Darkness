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
            
        } 
    }

    void OnTriggerEnter2D(Collider2D target) 
    {   
        if (target.CompareTag("bullet"))
        {       
            //zhealth -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            zhealth -=1;
            Destroy(target.gameObject);
        }
        
    }
    
}
