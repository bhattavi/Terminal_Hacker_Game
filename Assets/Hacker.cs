using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
   
{
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    int level;
    string password;
    int random;
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

        if (input.Equals("main"))
        {
     
            ShowMainMenu();
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
        if (input.Equals("clear"))
        {
            Terminal.ClearScreen();
        }
        else if (input.Equals("1"))
        {
            level = 1;
            random = UnityEngine.Random.Range(0, 6);
            Debug.Log(random);
            password = level1Passwords[random];
            StartGame();
        }
        else if (input.Equals("2"))
        {
            level = 2;
            UnityEngine.Random.Range(0, 5);
            Debug.Log(random);
            password = level2Passwords[random];
            StartGame();
        }
        else if (input.Equals("3"))
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Enter a valid input");
        }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Please enter your password: ");
        currentScene = Screen.Password;
    }
    void RunPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well done");
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
            
        }
    }




}
