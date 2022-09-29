using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    public int bricksLeft;
    public GameObject NextLevelButton;
    public GameObject paddle;

    private void Awake()
    {
        NextLevelButton = GameObject.Find("NextLevelButton");
        NextLevelButton.gameObject.SetActive(false);
        _gameManager = FindObjectOfType<GameManager>();
        bricksLeft = FindObjectsOfType<Brick>().Length;
        SetupLifeCounter();
    }

    private void SetupLifeCounter()
    {
        GameObject livesContainer = GameObject.Find("Lives");
        float nextX = 0;

        for (int i = 0; i < _gameManager.GetLives(); i++)
        {
            GameObject go = Instantiate(paddle, livesContainer.transform) ;
            go.transform.localPosition = new Vector3(nextX, 0, 0);
            go.GetComponent<Paddle>().enabled = false;
            nextX += paddle.GetComponent<SpriteRenderer>().bounds.size.x + 2f;
        }
    }

    internal void BrickDestroyed()
    {
        bricksLeft--;
        if (bricksLeft == 0)
        {
            NextLevelButton.gameObject.SetActive(true);
        }
    }

    public void NextLEvel()
    {
        _gameManager.NewLevel();
    }
}
