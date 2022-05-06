using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().PlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene("GameOver");
    }
}
