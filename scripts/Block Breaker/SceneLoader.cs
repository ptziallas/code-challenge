using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    GameStatus gameStatus; //1

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>(); //1 8a borouse na einai sto idio to method
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void ResetScore()
    {
        gameStatus.DestroyInstance();  //1
        //FindObjectOfType<GameStatus>().DestroyInstance();  2
    }

}
