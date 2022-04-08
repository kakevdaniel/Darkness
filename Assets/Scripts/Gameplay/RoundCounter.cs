using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public static int roundCounter = 1;
    Text Round;

    void Start()
    {
        Round = GetComponent<Text>();
    }

    void Update()
    {
        Round.text = "ROUND " + roundCounter;
    }
}
