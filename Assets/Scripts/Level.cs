using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        FindObjectOfType<GameManager>().SetupGame();
    }
}
