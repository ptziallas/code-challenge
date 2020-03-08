using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;
    [SerializeField] public SceneLoader sceneLoader;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    /*void Update() 
    {
      
    }*/
    
    public void HigherButton()
    {
        min = guess + 1;
        NextGuess();
    }

    public void LowerButton()
    {
        max = guess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max +1);
        guessText.text = guess.ToString();
        checkbounds();
    }
   
    void FinalGuess()
    {
        sceneLoader.LoadNextScene();
    }

    void checkbounds()
    {
        if (min >= max) 
        {
            if (min > max)
            {
                guess--;
            }
            FinalGuess();
        }
    }

}
