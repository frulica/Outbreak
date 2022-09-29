using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public int ballSpeed;

    public new Rigidbody2D rigidbody { get; private set; }
    Animator anim;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidbody.velocity = force.normalized * ballSpeed;
    }

    public Vector2 GetVelocity()
    {
        return rigidbody.velocity;
    }

    public void Hit()
    {
        anim.Play("BallHit",0,0);
        rigidbody.velocity = rigidbody.velocity.normalized * ballSpeed;
        //Debug.Log("HIT");
    }
}
