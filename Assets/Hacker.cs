using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
   
{
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
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
        bool isValidInput = (input == "1" || input == "2" || input == "3");
        if (input.Equals("clear"))
        {
            Terminal.ClearScreen();
        }
        else if (isValidInput)
        {
            level = int.Parse(input);
            StartGame(level);
        }
        else if(input == "007")
        {
            Terminal.WriteLine("Please enter a valid input Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Enter a valid input");
        }
    }

    void StartGame(int level)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password: ");
        currentScene = Screen.Password;
        switch(level){
            case 1:
               
                password = level1Passwords[UnityEngine.Random.Range(0, 6)];
                break;
            case 2:
                
                password = level2Passwords[UnityEngine.Random.Range(0, 5)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, 5)];
                break;
            default:
                Debug.Log("Error something is wrong");
                break;

        }
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
