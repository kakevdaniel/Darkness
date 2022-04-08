using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public static int ammoValue = 0;
    Text ammo;

    void Start()
    {
        ammo = GetComponent<Text>();
    }

    void Update()
    {
        ammo.text = "Ammo: " + ammoValue;
    }
}
