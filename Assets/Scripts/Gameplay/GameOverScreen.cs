using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Score.scoreValue = 0;
        RoundCounter.roundCounter = 1;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
