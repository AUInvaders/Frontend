using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject user_display;
    public GameObject pass_display;

    private string Username;
    private string Password;
    private string[] Lines;
    private string DecryptedPassword;


    public void LoginButton()
    {
        bool uname = false;
        bool pasw = false;
        
        if (Username != "")
        {
            if(System.IO.File.Exists(@"C:/UnityTestFolder/"+Username+".txt"))
            {
                uname = true;
                Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/"+Username+".txt");
                user_display.GetComponent<Text>().text = "";
            }
            else
            {
                Debug.LogWarning("Username is invalid!");
                user_display.GetComponent<Text>().text = "Username is invalid!";
                user_display.GetComponent<Text>().color = Color.red;
            }
        }
        else
        {
            Debug.LogWarning("Username field is empty");
            user_display.GetComponent<Text>().text = "Username field is empty";
            user_display.GetComponent<Text>().color = Color.red;
        }

        
        if (Password != ""){
            if (System.IO.File.Exists(@"C:/UnityTestFolder/"+Username+".txt")){
                int i = 1;
                foreach(char c in Lines[1]){
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPassword += Decrypted.ToString();
                }
                if (Password == DecryptedPassword)
                {
                    pasw = true;
                }
                else
                {
                    Debug.LogWarning("Password is invalid!");
                    pass_display.GetComponent<Text>().text = "Password is invalid!";
                    pass_display.GetComponent<Text>().color = Color.red;
                }
            } else
            {
                Debug.LogWarning("Password is invalid!");
                pass_display.GetComponent<Text>().text = "Password is invalid!";
                pass_display.GetComponent<Text>().color = Color.red;
            }
        } else 
        {
            Debug.LogWarning("Password field is empty");
            pass_display.GetComponent<Text>().text = "Password field is empty";
            pass_display.GetComponent<Text>().color = Color.red;
        }

        if (uname == true && pasw == true)
        {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            user_display.GetComponent<Text>().text = "";
            pass_display.GetComponent<Text>().text = "Login Successful";
            pass_display.GetComponent<Text>().color = Color.green;
            print("Login Sucessful");
            //SceneManager.LoadScene(1); - Når vi skal implementere ingame menu
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
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                LoginButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(2);
    }
}
