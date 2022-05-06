using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public Vector2 direction;

    public new Rigidbody2D rigidbody { get; private set; }

    public float speed = 1;

    public float maxBounceAngle = 75;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rigidbody.MovePosition(rigidbody.position + (direction * speed) * Time.deltaTime);
        }
    }


    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //Debug.Log("Frire");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = new Vector2(context.ReadValue<Vector2>().x, 0);
        }
        
        if (context.canceled)
        {
            direction = new Vector2(0, 0);
        }
    }


    private void LateUpdate()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;

            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.ballSpeed;
        }
    }
}
