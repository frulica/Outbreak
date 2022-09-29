using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameData gameData;

    public int level;
    TextMeshPro _scoreText;

    public int score;
    public int starting_lives;
    private int lives;

    internal void SetupGame()
    {
        level = 1;
        score = 0;
        lives = gameData.startingLives;
    }



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        SetupGame();
    }

    internal int GetLives()
    {
        return lives;
    }

    public void AddToScore(int points) 
    {
        score += points;
        if (_scoreText == null)
        {
            _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        }
        _scoreText.text = score.ToString();
    }

    internal void PlayerDead()
    {
        lives--;

        if (lives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void NewLevel()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        _scoreText.text = score.ToString();
    }
}
