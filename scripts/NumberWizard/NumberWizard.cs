using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    
    int max;
    int min;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {

        max = 1000;
        min = 1;
        guess = 500;

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("I would like you to pick a number.");
        Debug.Log("The highest number you can pick is: " + max + ".");
        Debug.Log("The lowest number you can pick is: " + min + ".");
        Debug.Log("Please tell me if your number is higher or lower than: " + guess + ".");
        Debug.Log("Push Up means Higher.Push Down means Lower.Push Enter means Corrent!");
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("So your number is over: " + guess + ".");
            min = guess;
            AutoCompleteUpper();
            NextGuess(); 
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("So your number is under: " + guess + ".");
            max = guess;
            AutoCompleteLower();
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            NumberGuess();
        }
    }
    
    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("Is it: " + guess + "?");
    }
   
    void AutoCompleteUpper()
    {
        if (guess == max - 1)
        {
            guess = max;
            NumberGuess();
        }
    }
   
    void AutoCompleteLower()
    {
        if (min == guess)
        {
            NumberGuess();
        }
    }

    void NumberGuess()
    {
        Debug.Log("Your number should be: " + guess + ".");
        StartGame();
    }

}
