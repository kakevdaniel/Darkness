using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    public void PlayGame()
    {

        SceneManager.LoadScene("Game");

        Score.scoreValue = 0;
        RoundCounter.roundCounter = 1;
    }
    public void LeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
    public void LogOut()
    {
        SceneManager.LoadScene("Login");
        DBmanager.LogOut();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
