using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WebSocketSharp;
using WebSocketSharp.Server;

public class RegisterMenu : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject confirmpassword;
    public GameObject wronguser_display;
    public GameObject wrongpass_display;
    public GameObject wrongconfpass_display;


    private string Username;
    private string Password;
    private string ConfPassword;
    private string form;
    

    private bool UserExists(string Username)
    {
        if (Username != "")
        {
            if (!System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt"))
            {
                wronguser_display.GetComponent<Text>().text = "";
                return true;
            }
            else
            {
                Debug.LogWarning("Username is already taken");
                wronguser_display.GetComponent<Text>().text = "Username is already taken";
                wronguser_display.GetComponent<Text>().color = Color.red;
                return false;
            }
        }
        else
        {
            Debug.LogWarning("Username field is empty");
            wronguser_display.GetComponent<Text>().text = "Field is empty";
            wronguser_display.GetComponent<Text>().color = Color.red;
            return false;
        }
    }

    private bool PasswordValid(string Password)
    {
        if (Password != "")
        {
            if (Password.Length > 6)
            {
                return true;
            }
            else
            {
                Debug.LogWarning("Password have to be atleast 7 Characters long");
                wrongpass_display.GetComponent<Text>().text = "Atleast 7 Characters long";
                wrongpass_display.GetComponent<Text>().color = Color.red;
                return false;
            }
        }
        else
        {
            Debug.LogWarning("Password field is empty");
            wrongpass_display.GetComponent<Text>().text = "Field is empty";
            wrongpass_display.GetComponent<Text>().color = Color.red;
            return false;
        }
    }

    private bool ConfPasswordValid(string ConfPassword)
    {
        if (ConfPassword != "")
        {
            if (ConfPassword == Password)
            {
                return true;
            }
            else
            {
                Debug.LogWarning("Passwords Don't match");
                wrongconfpass_display.GetComponent<Text>().text = "Passwords Don't match";
                wrongconfpass_display.GetComponent<Text>().color = Color.red;
                return false;
            }
        }
        else
        {
            Debug.LogWarning("Confirm password field is empty");
            wrongconfpass_display.GetComponent<Text>().text = "Field is empty";
            wrongconfpass_display.GetComponent<Text>().color = Color.red;
            return false;
        }
    }

    public void RegisterButton()
    {
        bool uname = false;
        bool pasw = false;
        bool confpass = false;

        uname = UserExists(Username);

        pasw = PasswordValid(Password);

        confpass = ConfPasswordValid(ConfPassword);
        

        if(uname == true && pasw == true && confpass == true)
        {
           
            form = (Username + Environment.NewLine + Password);
            System.IO.File.WriteAllText(@"C:/UnityTestFolder/" + Username + ".txt", form);
            
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmpassword.GetComponent<InputField>().text = "";
            wronguser_display.GetComponent<Text>().text = "";
            wrongpass_display.GetComponent<Text>().text = "";
            wrongconfpass_display.GetComponent<Text>().text = "Registration Complete";
            wrongconfpass_display.GetComponent<Text>().color = Color.green;
            print("Registration Complete");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confirmpassword.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(Password != "" && Username != "" && ConfPassword != "")
            {
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confirmpassword.GetComponent<InputField>().text;
    }

    public void GoBackToLogin()
    {
        SceneManager.LoadScene(1);
    }
}
