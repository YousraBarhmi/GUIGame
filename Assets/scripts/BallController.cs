using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{
    public float initialForce = 50f; // Initial force applied to the ball
    public float forceIncrease = 20f; // Amount by which force increases on collision
    public float sizeIncrease = 5f; // Amount by which the ball's size increases on collision with the player
    public float gameOverScaleThreshold = 80f; // Scale threshold for game over

    public float jumpForce = 25f; 
    private Rigidbody2D rb;
    public GameOverManager gameOverManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Apply initial force to the ball
        rb.AddForce(Vector2.right * initialForce, ForceMode2D.Impulse);
        gameOverManager = FindObjectOfType<GameOverManager>();

        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found in the scene!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Increase force
        rb.AddForce(rb.velocity.normalized * forceIncrease, ForceMode2D.Impulse);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        // // Change direction
        // Vector2 normal = collision.contacts[0].normal;
        // Vector2 reflectedDirection = Vector2.Reflect(rb.velocity.normalized, normal);
        // rb.velocity = reflectedDirection * rb.velocity.magnitude;

        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the size of the ball
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);

            // Check if the ball's scale exceeds the game over threshold
            if (transform.localScale.x > gameOverScaleThreshold)
            {
                // Call game over
                gameOverManager.GameOver();
            }
        }
    }


}
