using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI usertext;
    
    private void Start()
    {
        leaderBoard();
    }
    public void leaderBoard()
    {
        StartCoroutine(LeaderBoard());
    }

    IEnumerator LeaderBoard()
    {
        WWWForm form = new WWWForm();

        WWW www = new WWW("http://localhost/darkness/leaderboard.php", form);
        yield return www;
        usertext.text = www.text;
    }


}
