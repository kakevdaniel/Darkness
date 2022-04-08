using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }
    public void registerScene()
    {
        SceneManager.LoadScene("Register");
    }
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/darkness/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBmanager.userID = int.Parse(www.text.Split('\t')[2]);
            DBmanager.username = nameField.text;
            DBmanager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("Menu");
            Debug.Log(DBmanager.userID);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
