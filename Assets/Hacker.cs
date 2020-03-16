using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
   
{
    const string menuHint = "Enter menu at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "aviation", "gravity", "supersonic", "thrust", "combustor" };
    int level;
    string password;
    enum Screen {MainMenu, Password, Win};

    Screen currentScene = Screen.MainMenu;
  
    void Start()
    {
        ShowMainMenu();
        

    }
    void ShowMainMenu()
    {
        currentScene = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA\n");
        Terminal.WriteLine("Enter your selection:");
       

    }

    void OnUserInput(string input)
    {
        input = input.ToLower();

        if (input.Equals("menu"))
        {
     
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if(currentScene == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScene == Screen.Password)
        {
            RunPassword(input);
        }

    }

    

    void RunMainMenu(string input)
    {
        bool isValidInput = (input == "1" || input == "2" || input == "3");
        if (input.Equals("clear"))
        {
            Terminal.ClearScreen();
        }
        else if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if(input == "007")
        {
            Terminal.WriteLine("Please enter a valid input Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Enter a valid input");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScene = Screen.Password;
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

  void SetRandomPassword()
    {
        switch (level)
        {
            case 1:

                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:

                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.Log("Invalid level number");
                break;


        }
    }

    void RunPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScene();
            
        }
        else
        {
            AskForPassword();
            
        }
    }

    void DisplayWinScene()
    {
        currentScene = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book.......");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
               );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 3:
                Terminal.WriteLine("You are going to mars!");
                Terminal.WriteLine(@"
  ##
 #####
######
 #####
  ##

"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        }
    }
}
