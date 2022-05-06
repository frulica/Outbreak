using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brick : MonoBehaviour
{
    public int health;
    public int pointsPerHP;
    public BrickColors brickColors;

    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private int points;
    private GameManager _gameManager;

    Camera _mainCamera;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        points = pointsPerHP * health;
        _mainCamera = Camera.main;

        _spriteRenderer.color = brickColors.color[health];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;

        _spriteRenderer.color = brickColors.color[health];

        if (health < 1)
        {
            Die();
        }

        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.Hit();
        _mainCamera.GetComponent<ScreenShake>().StartShake();


        _rigidBody.velocity = ball.GetVelocity() * -1f;
        _rigidBody.AddTorque(300);
    }

    private void Die()
    {
        _boxCollider.enabled = false;
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        _rigidBody.gravityScale = 1;

        FindObjectOfType<GameManager>().AddToScore(points);
    }

    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().color = brickColors.color[health];
    }
}
