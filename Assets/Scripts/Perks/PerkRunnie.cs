using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkRunnie : MonoBehaviour
{
    public GameObject Perk;

    public static bool IsPerk;
    void Start()
    {
        Perk.SetActive(false);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Perk.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Perk.SetActive(false);
        }
    }
}
