using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50f; // Adjust this value to control the player's movement speed
    public float jumpForce = 30f; // Adjust this value to control the player's jump force
    public float gravityScale = 2f; // Adjust this value to control the player's gravity scale
    public float sizeIncrease = 5f;

    public GameObject Ball;
    private Rigidbody2D rb;
    private bool isGrounded = false; // Flag to track if the player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; // Set the gravity scale
    }

    public void Jump()
    {
        if (isGrounded) // Only jump if the player is grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Update grounded flag
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with an obstacle tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true; // Update grounded flag
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            // Increase the size of the ball
        }
    }

    void Update()
    {
        // Get input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement amount based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Apply movement to the player's position
        transform.Translate(movement);

        // Jump when the jump button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
