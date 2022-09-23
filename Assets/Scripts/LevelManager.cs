using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    public int bricksLeft;
    public Button NextLevelButton;
    private void Awake()
    {
        NextLevelButton.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().SetupGame();
        bricksLeft = FindObjectsOfType<Brick>().Length;
    }

    internal void BrickDestroyed()
    {
        bricksLeft--;
        if (bricksLeft == 0)
        {
            NextLevelButton.gameObject.SetActive(true);
        }
    }
}
