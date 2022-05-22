using UnityEngine;
using System.Collections;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{
    FirebaseAuth auth; 

    public InputField email;
    public InputField password;
    public Text textInfo;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += Auth_StateChanged;
        Auth_StateChanged(this, null);
        auth.SignOut();
    }

    private void Auth_StateChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != null)
        {
            textInfo.text = "¬ход выполнен" + auth.CurrentUser.Email;
            SceneManager.LoadScene(1);
        }
        else
        {
            textInfo.text = "¬ведите свою почту и пароль, чтобы войти";
        }
    }
    public void ButtonLogin()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
    }

}