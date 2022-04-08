using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        WWW www = new WWW("http://localhost/darkness/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created succesfully");
            SceneManager.LoadScene("Login");
        }
        else
        {
            Debug.Log("User cretion failed. Error#" + www.text);
        }
    }
    public void loginScreen()
    {
        SceneManager.LoadScene("Login");
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
