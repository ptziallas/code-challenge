using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [Range(0.1f , 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed =2;
    [SerializeField] int currentScore = 0; //why grey

    private void Awake() //singleton
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CurrentScoreText();
    }

    private void CurrentScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;  //timeScale metavlhth tou Time dn 8elei dhlwma?
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        CurrentScoreText();
    }

    public void DestroyInstance()
    {
        Destroy(gameObject);
    }

}
