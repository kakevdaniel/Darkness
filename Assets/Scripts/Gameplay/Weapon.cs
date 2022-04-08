using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    public RuntimeAnimatorController currentWeaponAnim;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public string weaponName;
    public int damage = 1;
    
    public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, GameObject.Find("FirePoint").transform.rotation);
    }
}
