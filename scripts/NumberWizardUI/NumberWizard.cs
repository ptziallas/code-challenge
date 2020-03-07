using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; //test John

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
   // TextMeshProUGUI finalGuessText;
    int guess;

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
        checkbounds();
        NextGuess();
    }

    public void LowerButton()
    {
        max = guess - 1;
        checkbounds();
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max +1);
       // Debug.Log(min);
       // Debug.Log(max);
       // Debug.Log(guess);
        guessText.text = guess.ToString();
        FinalGuessText();
    }
   
    void FinalGuess()
    {
        FinalGuessText();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //test John
        SceneManager.LoadScene(currentSceneIndex + 1);  //test John
    }

    void FinalGuessText()
    {
        //finalGuessText.text = guess.ToString();
    }

    void checkbounds()
    {
        if (min >= max)
        {
            FinalGuess();
        }
    }

}
