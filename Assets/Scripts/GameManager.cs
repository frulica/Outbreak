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

    internal void SetupGame()
    {
        level = 1;
        score = 0;
        lives = gameData.startingLives;
    }

    public int score;
    public int lives;

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
    }

    public void NewLevel()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        _scoreText.text = score.ToString();
    }
}
