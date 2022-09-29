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
    public LevelManager _levelManager;

    float timeLeft, elapsedTime;
    public Color targetColor;

    Camera _mainCamera;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        points = pointsPerHP * health;
        _mainCamera = Camera.main;
        _levelManager = FindObjectOfType<LevelManager>();

        _spriteRenderer.color = brickColors.color[health];
    }

    public IEnumerator FadeColor()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            _spriteRenderer.material.color = Color.Lerp(_spriteRenderer.material.color, targetColor, elapsedTime / timeLeft);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;

        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.Hit();
        _mainCamera.GetComponent<ScreenShake>().StartShake();

        _rigidBody.velocity = ball.GetVelocity() * -1f;
        _rigidBody.AddTorque(300);

        if (health < 1)
        {
            Die();
        }
        else
        {
            _spriteRenderer.color = brickColors.color[health];
        }
    }

    private void Die()
    {
        _boxCollider.enabled = false;
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        _rigidBody.gravityScale = 1;

        _levelManager.BrickDestroyed();

        timeLeft = 30f;
        elapsedTime = 0f;
        StartCoroutine(FadeColor());

        FindObjectOfType<GameManager>().AddToScore(points);
    }

    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().color = brickColors.color[health];
    }


}
