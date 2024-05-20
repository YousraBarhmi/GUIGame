using UnityEngine;
using UnityEngine.UI; // Import Unity's UI namespace

public class ScoreManager : MonoBehaviour
{
    public float timeThreshold = 1000f; // Time threshold for scoring (2 seconds in this case)
    public int scoreIncrease = 10; // Amount to increase the score
    public int scoreDecrease = 5; // Amount to decrease the score

    private float timeSinceLastTouch = 0f; // Time since the ball was last touched
    private int score = 0; // Current score

    public Text scoreText; // Reference to the Text component to display the score

    void Update()
    {
        // Update the time since the last touch
        timeSinceLastTouch += Time.deltaTime;

        // Check if the time threshold has been reached
        if (timeSinceLastTouch >= timeThreshold)
        {
            // Increase the score
            IncreaseScore();
        }
        else
        {
            // Decrease the score
            DecreaseScore();
        }

        // Update the score text
        UpdateScoreText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset the time since last touch when collision occurs
        timeSinceLastTouch = 0f;
    }

    void IncreaseScore()
    {
        // Increase the score by the specified amount
        score += scoreIncrease;
        Debug.Log("Score increased! Current score: " + score);
    }

    void DecreaseScore()
    {
        // Decrease the score by the specified amount
        score -= scoreDecrease;
        Debug.Log("Score decreased! Current score: " + score);
    }

    void UpdateScoreText()
    {
        // Update the Text component with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
